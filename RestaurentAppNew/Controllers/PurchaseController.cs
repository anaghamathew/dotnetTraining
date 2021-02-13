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
            //ViewBag.totalMoviesCount = movies.Count();
            return View(foodCategoryViewModel);
        }

        public IActionResult ThankYou()
        {
            return View();
        }
        /*public IActionResult Index()
        {
            return View();
        }*/
    }

    
}
