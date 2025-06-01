using tiendaRopaEagleDecv.Data.Dtos.DtoAutenticacion;

namespace tiendaRopaEagleDecv.Services.Interfaces
{
    public interface IUsuarioServicio
    {
        Task CrearUsuarioAsync(UsuarioRegistroDTO usuarioDto);
    }
}
