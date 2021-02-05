using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMovieApp.Controllers
{
    public class MovieController1 : Controller
    {
       public string Index()
        {
            return "this is my default";
        }
        public string Welcome()
        {
            return "this is my welcome";
        }
    }
}
