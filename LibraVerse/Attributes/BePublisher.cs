namespace LibraVerse.Attributes
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    using LibraVerse.Core.Contracts;

    using System.Security.Claims;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;

    public class BePublisherAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            IPublisherService? publisherService = context.HttpContext.RequestServices.GetService<IPublisherService>();

            if (publisherService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (publisherService != null && publisherService.ExistsByUserIdAsync(context.HttpContext.User.Id()).Result == false)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            }
        }
    }
}