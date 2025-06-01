using Microsoft.AspNetCore.Mvc;
using tiendaRopaEagleDecv.Data.Dtos.DtoAutenticacion;
using tiendaRopaEagleDecv.Services.Interfaces;

namespace tiendaRopaEagleDecv.Controllers.AdministracionUsuarios
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDTO request)
        {
            var response = await _authService.Login(request);
            if (response == null)
                return Unauthorized("Credenciales inválidas");

            return Ok(response);
        }
    }
}
