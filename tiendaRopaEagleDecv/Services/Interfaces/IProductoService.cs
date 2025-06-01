using tiendaRopaEagleDecv.Data.Dtos.DtoProductos;

namespace tiendaRopaEagleDecv.Services.Interfaces
{
    public interface IProductoService
    {
        Task<IEnumerable<ProductoDTO>> Listar();
        Task<ProductoDTO> ObtenerPorId(int id);
        Task<bool> Crear(ProductoDTO producto);
        Task<bool> Actualizar(ProductoDTO producto);
        Task<bool> Eliminar(int id);
    }
}
