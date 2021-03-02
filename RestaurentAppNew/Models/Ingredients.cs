using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurentAppNew.Models
{
    public class Ingredients
    {
        public int Id { get; set; }
        public string Recipe { get; set; }

        public Food food { get; set; }

    }
}
