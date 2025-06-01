using tiendaRopaEagleDecv.Data.Dtos.DtoAutenticacion;

namespace tiendaRopaEagleDecv.Services.Interfaces
{
    public interface IRolServicio
    {
        Task CrearRolAsync(string nombre);
    }
}
