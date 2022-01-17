using Microsoft.AspNetCore.Mvc.Filters;

namespace RockLegends.Filters
{
    public class MyLoggingFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine(context.ActionDescriptor.DisplayName);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            
        }

        //public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        //{
        //    await next.Invoke();
        //}

        //public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        //{
        //    await next.Invoke();
        //}
    }
}
