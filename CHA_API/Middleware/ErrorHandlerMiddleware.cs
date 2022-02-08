using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Serilog;
using Newtonsoft.Json;
using CHA_API.Model;
using CHA_API.Model.ExceptionModel;

namespace CHA_API.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            StandardErrorMessage<string> errorMessage = new StandardErrorMessage<string>();
            HttpResponse response = context.Response;
            string methodName = string.Empty;
            string fileName = string.Empty;
            object inputParameter = null;
            string messageTemplate = "Error occured in {methodName} method inside {fileName} file with given input parameter: {inputParameter}";

            switch (exception)
            {
                case KeyNotFoundException e:
                    // not found error
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    errorMessage.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case UnhandledException e:
                    // not found error
                    int statusCode = e.StatusCode != 0 ? e.StatusCode : (int)HttpStatusCode.InternalServerError;
                    response.StatusCode = statusCode;
                    errorMessage.StatusCode = statusCode;
                    methodName = e.MethodName;
                    fileName = e.FileName;
                    inputParameter = e.InputParameter;
                    break;
                case ObjectNotFoundException e:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorMessage.StatusCode = (int)HttpStatusCode.BadRequest;
                    methodName = e.MethodName;
                    fileName = e.FileName;
                    inputParameter = e.InputParameter;
                    break;
                default:
                    // unhandled error
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorMessage.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            errorMessage.ErrorMessage = exception.Message;
            _logger.Error(exception, messageTemplate, new object[] { methodName, fileName, JsonConvert.SerializeObject(inputParameter) });
            await response.WriteAsync(JsonConvert.SerializeObject(errorMessage));
        }
    }
}
