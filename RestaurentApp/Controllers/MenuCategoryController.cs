using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurentApp.Controllers
{
    public class MenuCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
