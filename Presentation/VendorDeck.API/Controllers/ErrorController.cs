using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VendorDeck.API.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/error")]
        [HttpGet]
        public IActionResult Error()
        {
            var errorInfo = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
              
            return Problem(detail: errorInfo.Path,statusCode: StatusCodes.Status500InternalServerError);
        }
    }
}
