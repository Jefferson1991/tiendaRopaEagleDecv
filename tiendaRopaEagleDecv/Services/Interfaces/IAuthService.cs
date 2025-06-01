using tiendaRopaEagleDecv.Data.Dtos.DtoAutenticacion;

namespace tiendaRopaEagleDecv.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDTO> Login(LoginRequestDTO request);
    }
}
