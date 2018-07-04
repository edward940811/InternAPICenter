using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using NLog;
using Risk.API.Models;
using Risk.Model.Enums;
using Risk.Model.Exceptions;

namespace ESHClouds.ApiCenter.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        protected static Logger _logger = LogManager.GetCurrentClassLogger();

        public void OnException(ExceptionContext context)
        {
            var httpcode = HttpStatusCode.InternalServerError;
            var Code = ExceptionCode.InvalidRequest;
            var message = new List<string>();
            if (context.Exception.GetType() == typeof(AssemblyLauncherException))
            {
                // Http Code : 405
                httpcode = HttpStatusCode.MethodNotAllowed;
                Code = ExceptionCode.AssemblyLauncherError;
                message.Add(context.Exception.Message);
                _logger.Warn(context.Exception, String.Join(",", message.ToArray()));
            }
            else if (context.Exception.GetType() == typeof(ValidationModelException))
            {
                // Http Code : 403
                httpcode = HttpStatusCode.Forbidden;
                Code = ExceptionCode.InvalidModel;
                foreach (var msg in context.Exception.Message.Split(new[] { "\r\n" }, StringSplitOptions.None))
                {
                    if (string.IsNullOrEmpty(msg)) continue;
                    message.Add(msg);
                }
                _logger.Warn(context.Exception, String.Join(",", message.ToArray()));
            }
            else if (context.Exception.GetType() == typeof(BusinessModelException))
            {
                // Http Code : 403
                httpcode = HttpStatusCode.Forbidden;
                Code = context.Exception.Message;
                _logger.Info(context.Exception);
            }
            else
            {
                message.Add(context.Exception.ToString());
                _logger.Fatal(context.Exception.ToString());
            }

            var error = new ApiResponse()
            {
                Status = "error",
                HttpCode = httpcode,
                Code = Code,
                Messages = message
            };
            context.Result = new ObjectResult(error) { StatusCode = (int)httpcode };
        }
    }
}
