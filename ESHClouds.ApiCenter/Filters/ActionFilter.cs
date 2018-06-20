using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Risk.API.Filters
{
    public class ActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null)
            {
                var model = ((Microsoft.AspNetCore.Mvc.ObjectResult)context.Result)?.Value;
                //var results = new ApiResponse()
                //{
                //    Status = "success",
                //    HttpCode = HttpStatusCode.OK,
                //    Code = "success",
                //    Result = model
                //};
                context.Result = new JsonResult(model);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}