using DATA.DTO;

namespace Interviewssss.Service.Identity
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginDTO dto);

        Task<string> CreateToken();
    }
}
