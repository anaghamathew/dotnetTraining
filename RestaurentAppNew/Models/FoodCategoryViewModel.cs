﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurentAppNew.Models
{
    public class FoodCategoryViewModel
    {
        public List<Food> Foods { get; set; }
        public SelectList Catgeory { get; set; }
        public string FoodCategory { get; set; }

        public string SearchString { get; set; }
    }
}
