using Microsoft.AspNetCore.Mvc;
using tiendaRopaEagleDecv.Data.Dtos.DtoAutenticacion;
using tiendaRopaEagleDecv.Services.Interfaces;

namespace tiendaRopaEagleDecv.Controllers.AdministracionUsuarios
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioServicio _usuarioServicio;

        public UsuariosController(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] UsuarioRegistroDTO usuarioDto)
        {
            await _usuarioServicio.CrearUsuarioAsync(usuarioDto);
            return Ok("Usuario creado correctamente.");
        }
    }
}
