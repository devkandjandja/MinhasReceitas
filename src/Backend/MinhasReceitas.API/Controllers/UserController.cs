using Microsoft.AspNetCore.Mvc;
using MinhasReceitas.Communication.Requests;
using MinhasReceitas.Communication.Responses;

namespace MinhasReceitas.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponsesRegisteredUserJson), StatusCodes.Status201Created)]
        public IActionResult Register(RequestRegisterUserJson request)
        {
            return Created();
        }
    }
}