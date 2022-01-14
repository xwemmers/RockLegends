using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RockLegends.Filters
{
    public class GlobalAntiForgeryFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string method = context.HttpContext.Request.Method;

            if (method == "POST")
            {
                context.Filters.Add(new ValidateAntiForgeryTokenAttribute());
            }

        }
    }
}
