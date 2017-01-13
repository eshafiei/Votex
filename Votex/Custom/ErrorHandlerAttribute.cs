using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace Votex.Custom
{
    public class ErrorHandlerAttribute : HandleErrorAttribute
    {

        public override void OnException(ExceptionContext filterContext)
        {
            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            filterContext.Result = new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                {
                    success = false,
                    message = filterContext.Exception.Message 
                        + "\n\n Inner Exception: \n" + filterContext.Exception.InnerException.ToString().Substring(0,350)
                }
            };
            filterContext.ExceptionHandled = true;
        }
    }
}