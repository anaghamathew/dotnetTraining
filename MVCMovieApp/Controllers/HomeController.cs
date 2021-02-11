using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        public IActionResult Index()
        {
            return View();
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
