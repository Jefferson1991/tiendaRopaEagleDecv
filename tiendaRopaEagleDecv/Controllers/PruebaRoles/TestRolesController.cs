using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace tiendaRopaEagleDecv.Controllers.PruebaRoles
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestRolesController : ControllerBase
    {
        [HttpGet("solo-vendedor")]
        [Authorize(Roles = "Vendedor")]
        public IActionResult AccesoVendedor()
        {
            return Ok("Acceso permitido al Vendedor.");
        }

        [HttpGet("solo-administrador")]
        [Authorize(Roles = "Administrador")]
        public IActionResult AccesoAdministrador()
        {
            return Ok("Acceso permitido al Administrador.");
        }
    }
}
