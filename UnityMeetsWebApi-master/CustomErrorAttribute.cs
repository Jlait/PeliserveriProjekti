using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace assignment2
{
    public class LevelUnderThree : Exception
        {
            public LevelUnderThree ()
            { }

            public LevelUnderThree (string message) : base (message)
            { }

            public LevelUnderThree (string message, Exception inner) : base (message, inner)
            { }
        }
    public class CustomErrorAttribute : ExceptionFilterAttribute
    {
        public override void OnException (ExceptionContext context)
        {
            if (context.Exception is LevelUnderThree)
            {
                context.Result = new BadRequestObjectResult("Player Level Under 3! Swords require player level 3 or above!");
            }
        }
    }
}