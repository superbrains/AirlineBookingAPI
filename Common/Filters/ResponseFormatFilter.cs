using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.Filters
{
    public class ResponseFormatterFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null || context.HttpContext.Response.StatusCode != (int)HttpStatusCode.OK)
            {
                return;
            }

            var actionName = ((ControllerBase)context.Controller)
            .ControllerContext.ActionDescriptor.ActionName;

            //if (actionName.ToLower().Contains("export")) return;
         

            context.Result = context.Result is ObjectResult objectResult
                ? new JsonResult(new ServiceResponseData<object>(objectResult.Value)) : new JsonResult(ServiceResponseData.Success());
        }
    }
}
