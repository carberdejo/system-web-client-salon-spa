using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ProyClienteSpaHelena.Security
{
    public class AuthorizeSessionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session;
            var user = session.GetString("Usuario");

            if (string.IsNullOrEmpty(user))
            {
                // Redirige al login si no hay sesión activa
                context.Result = new RedirectToActionResult("Login", "Session", null);
            }

            base.OnActionExecuting(context);
        }
    }
}
