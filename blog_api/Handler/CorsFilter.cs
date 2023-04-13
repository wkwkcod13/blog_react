using Microsoft.AspNetCore.Mvc.Filters;

namespace blog_api.Handler
{
    public class CorsFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
            base.OnActionExecuting(context);
        }
    }
}
