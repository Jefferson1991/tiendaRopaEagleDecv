using Microsoft.AspNetCore.Mvc;
using tiendaRopaEagleDecv.Data.Dtos.DtoAutenticacion;
using tiendaRopaEagleDecv.Services.Interfaces;

namespace tiendaRopaEagleDecv.Controllers.AdministracionUsuarios
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolServicio _rolServicio;

        public RolesController(IRolServicio rolServicio)
        {
            _rolServicio = rolServicio;
        }

        [HttpPost]
        public async Task<IActionResult> CrearRol([FromBody] RolRegistroDTO rolDto)
        {
            await _rolServicio.CrearRolAsync(rolDto.Nombre);
            return Ok("Rol creado correctamente.");
        }
    }
}
