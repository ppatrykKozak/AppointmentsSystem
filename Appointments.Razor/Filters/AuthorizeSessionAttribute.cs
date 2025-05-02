using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Appointments.Razor.Filters
{
    public class AuthorizeSessionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var jwt = context.HttpContext.Session.GetString("jwtToken");
            if (string.IsNullOrEmpty(jwt))
            {
                context.Result = new RedirectToPageResult("/Auth/Login");
            }
        }
    }
}
