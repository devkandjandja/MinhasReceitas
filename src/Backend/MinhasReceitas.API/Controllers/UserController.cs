using Microsoft.AspNetCore.Mvc;
using MinhasReceitas.Application.UserCases.User.Register;
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
        public async Task<IActionResult> Register([FromServices] IRegisterUserUseCase useCase, [FromBody] RequestRegisterUserJson request)
        {       
            var result = await useCase.Execute(request);

            return Created(string.Empty, result);
        }
    }
}