using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurentAppNew.Data;
using RestaurentAppNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurentAppNew.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly RestaurentAppNewContext _context;
        public List<PurchaseOrder> PurchaseOrderList { get; private set; }
        public string shoppingCartId { get; set; }
        

        public PurchaseController(RestaurentAppNewContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index(string foodCategory, string searchString)
        {
            
            var foods = from m in _context.Food
                         select m;
            var categories = from c in _context.Category select c;
            /*IQueryable<string> genreQuery = from m in _context.Food
                                            orderby m.FoodCategory.Name
                                            select m.FoodCategory;
*/
            if (!String.IsNullOrEmpty(searchString))
            {
                foods = foods.Where(s => s.Name.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(foodCategory))
            {
                foods = foods.Where(x => x.FoodCategory.Name== foodCategory);
            }

            var foodCategoryViewModel = new FoodCategoryViewModel
            {
                CategoriesList = await categories.ToListAsync(),
                Foods = await foods.ToListAsync()
            };
            var PurchaseOrderListnew = GetPurchasedOrders();
           
            decimal? total = decimal.Zero;
            total = (from items in PurchaseOrderListnew
                     select (int?)items.Quantity * items.PurchasedFood.Price).Sum();

            var avgAge = (from items in PurchaseOrderListnew select items.PurchasedFood.Price).Average();
            var avgAgeee = (from items in PurchaseOrderListnew select items).Average(e=>e.PurchasedFood.Price);
            ViewData["orderTotal"] = total;
            ViewData["avgAge"] = avgAge;


            return View(foodCategoryViewModel);
        }

        public IActionResult ThankYou()
        {
            return View();
        }
        
        public async Task<IActionResult> AddToCart(int id)
        {

            var exisingFood = await _context.PurchaseOrder.FirstOrDefaultAsync(m => m.FoodId == id);

            if (exisingFood != null)
            {
                exisingFood.Quantity++;
            }
            else
            {
                PurchaseOrder purchaseOrder = new PurchaseOrder()
                {
                    Customer = "anagha",
                    Quantity = 1,
                    FoodId = id,
                   
                    DateCreated = DateTime.UtcNow
                };

                _context.Add(purchaseOrder);
            }
           
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ViewCart()
        {
            var PurchaseOrderListnew = GetPurchasedOrders();
            decimal? total = decimal.Zero;
            total = (from items in PurchaseOrderListnew
                               select (int?)items.Quantity * items.PurchasedFood.Price).Sum();
            ViewData["orderTotal"] = total;
            return View(PurchaseOrderListnew);
        }

        public List<PurchaseOrder> GetPurchasedOrders()
        {
         
            var restaurentAppNewContextCurent = _context.PurchaseOrder.Include(f => f.PurchasedFood).ToList();
          return restaurentAppNewContextCurent.Where(p => p.Customer == "anagha").ToList();
        }
       
        public async Task<IActionResult> Remove(int? id)

          {
            if (id == null)
            {
                return NotFound();
            }
            var orderFood = await _context.PurchaseOrder.FindAsync(id);
           
            if (orderFood.Quantity > 1)
            {
                orderFood.Quantity--;
               
            }
            else {
                _context.PurchaseOrder.Remove(orderFood);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ViewCart));
        }
    }

    
}
