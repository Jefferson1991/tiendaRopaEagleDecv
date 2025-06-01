using Microsoft.EntityFrameworkCore;
using tiendaRopaEagleDecv.Data;
using tiendaRopaEagleDecv.Services.Interfaces;

namespace tiendaRopaEagleDecv.Services.Implementaciones
{
    public class RolServicio : IRolServicio
    {
        private readonly railwayContext _context;

        public RolServicio(railwayContext context)
        {
            _context = context;
        }

        public async Task CrearRolAsync(string nombre)
        {
            if (await _context.Roles.AnyAsync(r => r.Nombre == nombre))
                throw new Exception("El rol ya existe.");

            var rol = new Roles { Nombre = nombre };
            _context.Roles.Add(rol);
            await _context.SaveChangesAsync();
        }
    }
}
