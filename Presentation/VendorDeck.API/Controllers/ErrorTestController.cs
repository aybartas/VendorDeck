using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VendorDeck.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorTestController : ControllerBase
    {
        [HttpGet("not-found")]
        public ActionResult GetNotFound()
        {
            return NotFound();
        }

        [HttpGet("bad-request")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ProblemDetails { Title = "This is bad request"});
        }

        [HttpGet("unauthorized")]
        public ActionResult GetUnauthorized()
        {
            return Unauthorized();
        }

        [HttpGet("validation-error")]
        public ActionResult GetValidationError()
        {
            ModelState.AddModelError("Problem1", "this is first error");
            ModelState.AddModelError("Problem2", "this is second error");
            ModelState.AddModelError("Problem3", "this is third error");
            return ValidationProblem();
        }

        [HttpGet("server-error")]
        public ActionResult GetServerError()
        {
            throw new System.Exception("this is server error");
        }

    }
}
