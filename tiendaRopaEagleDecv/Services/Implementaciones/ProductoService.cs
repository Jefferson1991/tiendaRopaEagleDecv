using Microsoft.EntityFrameworkCore;
using tiendaRopaEagleDecv.Data;
using tiendaRopaEagleDecv.Data.Dtos.DtoProductos;
using tiendaRopaEagleDecv.Services.Interfaces;

namespace tiendaRopaEagleDecv.Services.Implementaciones
{
    public class ProductoService : IProductoService
    {
        private readonly railwayContext _context;

        public ProductoService(railwayContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductoDTO>> Listar()
        {
            return await _context.Productos
                .Select(p => new ProductoDTO
                {
                    IdProducto = p.IdProducto,
                    Codigo = p.Codigo,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    Precio = p.Precio ?? 0,
                    Marca = p.Marca,
                    ImagenUrl = p.ImagenUrl,
                    IdCategoria = p.IdCategoria ?? 0
                }).ToListAsync();
        }

        public async Task<ProductoDTO> ObtenerPorId(int id)
        {
            var p = await _context.Productos.FindAsync(id);
            if (p == null) return null;

            return new ProductoDTO
            {
                IdProducto = p.IdProducto,
                Codigo = p.Codigo,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Precio = p.Precio ?? 0,
                Marca = p.Marca,
                ImagenUrl = p.ImagenUrl,
                IdCategoria = p.IdCategoria ?? 0
            };
        }

        public async Task<bool> Crear(ProductoDTO producto)
        {
            var nuevo = new Productos
            {
                Codigo = producto.Codigo,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                Marca = producto.Marca,
                ImagenUrl = producto.ImagenUrl,
                IdCategoria = producto.IdCategoria
            };

            _context.Productos.Add(nuevo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(ProductoDTO producto)
        {
            var p = await _context.Productos.FindAsync(producto.IdProducto);
            if (p == null) return false;

            p.Codigo = producto.Codigo;
            p.Nombre = producto.Nombre;
            p.Descripcion = producto.Descripcion;
            p.Precio = producto.Precio;
            p.Marca = producto.Marca;
            p.ImagenUrl = producto.ImagenUrl;
            p.IdCategoria = producto.IdCategoria;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var p = await _context.Productos.FindAsync(id);
            if (p == null) return false;

            _context.Productos.Remove(p);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
