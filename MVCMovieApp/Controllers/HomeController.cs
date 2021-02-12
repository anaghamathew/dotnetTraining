using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCMovieApp.Controllers.filters;
using MVCMovieApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;


namespace MVCMovieApp.Controllers
{
    public class HomeController : Controller
    {
        // 
        // GET: /HelloWorld/

        [AddHeader("Author", "Rick Anderson")]
        public IActionResult Index()
        {
            return Content("examin headers");
        }

        [ServiceFilter(typeof(MyActionFilterAttribute))]
        public IActionResult Index2()
        {
            return Content("Header values by appconfiguration.");
        }
        [ShortCircuitingResourceFilter]
        public IActionResult Index3()
        {
            return Content("Successful access to resource filter- header is set.");
        }
        public void Privacy()
        {

        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public IActionResult Welcome(string name,int ID= 1)
        {
            ViewData["message"] = "Hello"+name;
            ViewData["ID"] = ID;
            return View();
        }
    }
}
