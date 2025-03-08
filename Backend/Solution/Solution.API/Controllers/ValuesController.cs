using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Solution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet(Name = "TesteUser")]
        public IActionResult LoginUsuario()
        {
            return Ok();
        }
    }
}
