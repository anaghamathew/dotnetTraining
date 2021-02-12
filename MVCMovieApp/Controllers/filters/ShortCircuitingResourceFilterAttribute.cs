using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMovieApp.Controllers.filters
{
    public class ShortCircuitingResourceFilterAttribute:Attribute, Microsoft.AspNetCore.Mvc.Filters.IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.Result = new ContentResult()
            {
                Content = "Resource unavailable - header not set."
            };
            
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }
    }
}
