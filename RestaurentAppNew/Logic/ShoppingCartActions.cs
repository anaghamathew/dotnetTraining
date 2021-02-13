using Microsoft.AspNetCore.Http;
using RestaurentAppNew.Data;
using RestaurentAppNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Web;

namespace RestaurentAppNew.Logic
{
    public class ShoppingCartActions 
    {
       /* public string ShoppingCartId { get; set; }
        private  RestaurentAppNewContext _context;

       
        public const string CartSessionKey = "CartId";
*/
        /*public void AddToCart(int id)
        {
            //ShoppingCartId = GetCartId();
            var cartItem = _context.ShoppingCartItems.SingleOrDefault(
          c => c.CartId == ShoppingCartId
          && c.FoodId == id);
            if (cartItem == null)
            {
                cartItem = new CartItem {
                    ItemId = Guid.NewGuid().ToString(),
                    FoodId = id,
                    CartId = ShoppingCartId,
                    Food = _context.Food.SingleOrDefault(
           p => p.Id == id),
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };
                _context.ShoppingCartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }
            _context.SaveChanges();
        }
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }
        public List<CartItem> GetCartItems()
        {
          //  ShoppingCartId = GetCartId();

            return _context.ShoppingCartItems.Where(
                c => c.CartId == ShoppingCartId).ToList();
        }
        *//*public string GetCartId()
        {
            if (HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class.     
                    Guid tempCartId = Guid.NewGuid();
                    HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return HttpContext.Current.Session[CartSessionKey].ToString();
        }
*/
    }
}
