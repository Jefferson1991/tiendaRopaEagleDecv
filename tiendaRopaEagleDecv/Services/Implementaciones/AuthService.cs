using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using tiendaRopaEagleDecv.Data;
using tiendaRopaEagleDecv.Data.Dtos.DtoAutenticacion;
using tiendaRopaEagleDecv.Services.Interfaces;

namespace tiendaRopaEagleDecv.Services.Implementaciones
{
   public class AuthService : IAuthService
    {
        private readonly railwayContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(railwayContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<AuthResponseDTO> Login(LoginRequestDTO request)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.IdRolNavigation)
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(request.Password, usuario.ContrasenaHash))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Name, usuario.NombreUsuario),
                    new Claim(ClaimTypes.Role, usuario.IdRolNavigation.Nombre)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AuthResponseDTO { Token = tokenHandler.WriteToken(token) };
        }
    }
}
