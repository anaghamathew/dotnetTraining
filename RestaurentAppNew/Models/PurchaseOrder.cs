using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurentAppNew.Models
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public string Customer { get; set; }

        public int Quantity { get; set; }
        public int FoodId { get; set; }

        public virtual Food PurchasedFood { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }
    }
}
