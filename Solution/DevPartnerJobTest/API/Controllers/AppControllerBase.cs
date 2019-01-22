using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AppControllerBase : ControllerBase
    {
        // [note] This method is a quick handling, but it could send an email to alert developers, for example
        protected IActionResult InternalServerError(object result)
        {
            var objectResult = new ObjectResult(
                new ResponseDescriptor<object>()
                {
                    Message = ResponseConstants.ContactUs,
                    Result = result,
                }
            );
            //
            return objectResult;
        }
    }
}
