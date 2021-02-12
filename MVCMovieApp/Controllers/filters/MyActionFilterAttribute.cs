using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using MVCMovieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMovieApp.Controllers.filters
{
    public class MyActionFilterAttribute: Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute
    {
        private readonly PositionOptions _settings;
        public MyActionFilterAttribute(IOptions<PositionOptions> options)
        {
            _settings = options.Value;
            Order = 1;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add(_settings.Title,
                                                     new string[] { _settings.Name });
            base.OnResultExecuting(context);
        }
    }
}
