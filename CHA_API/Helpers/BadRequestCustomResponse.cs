using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using CHA_API.Model;

namespace CHA_API.Helpers
{
    public static class BadRequestCustomResponse
    {
        public static BadRequestObjectResult BadRequestResponse(ActionContext actionContext)
        {
            StandardErrorMessage<List<string>> response = new StandardErrorMessage<List<string>>();
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            response.ErrorMessage = actionContext.ModelState.Where(modelError => modelError.Value.Errors.Count > 0)
                                                            .Select(modelError => modelError.Value.Errors.FirstOrDefault().ErrorMessage)
                                                            .ToList();
            return new BadRequestObjectResult(response);
        }
    }
}
