using Microsoft.EntityFrameworkCore;
using tiendaRopaEagleDecv.Data;
using tiendaRopaEagleDecv.Data.Dtos.DtoAutenticacion;
using tiendaRopaEagleDecv.Services.Interfaces;

namespace tiendaRopaEagleDecv.Services.Implementaciones
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly railwayContext _context;

        public UsuarioServicio(railwayContext context)
        {
            _context = context;
        }

        public async Task CrearUsuarioAsync(UsuarioRegistroDTO usuarioDto)
        {
            if (await _context.Usuarios.AnyAsync(u => u.NombreUsuario == usuarioDto.NombreUsuario))
                throw new Exception("El usuario ya existe.");

            string hashPassword = BCrypt.Net.BCrypt.HashPassword(usuarioDto.Contrasena);

            var usuario = new Usuarios
            {
                NombreUsuario = usuarioDto.NombreUsuario,
                Email = usuarioDto.Email,
                ContrasenaHash = hashPassword,
                IdRol = usuarioDto.IdRol,
                Activo = true,
                FechaCreacion = DateTime.UtcNow
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
