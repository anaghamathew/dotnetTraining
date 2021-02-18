using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurentAppNew.Models
{
    public class Food
    {
        public int Id { get; set; }
        [Required]
       
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [System.ComponentModel.DisplayName("Price (Rs.)")]
        public decimal Price { get; set; }

        public short Quantity { get; set; }

        public int CategoryId { get; set; }
        public virtual Category FoodCategory { get; set; }

        /*public virtual Ingredients Ingredients { get; set; }*/
    }
}
