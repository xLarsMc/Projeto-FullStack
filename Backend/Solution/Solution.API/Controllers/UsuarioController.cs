using Microsoft.AspNetCore.Mvc;
using Solution.Application.useCases.User;
using Solution.Communication.Requests;
using Solution.Communication.Responses;

namespace Solution.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> LoginUsuario([FromServices] IRegisterUserUseCase useCase,
                                          [FromBody] RequestUserRegisterJson request)
        {
            var result = await useCase.userRegister(request);

            return Created(string.Empty, result);
        }

    }
}
