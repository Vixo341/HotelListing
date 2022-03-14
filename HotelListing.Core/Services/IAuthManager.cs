using HotelListing.Core.DTOs;

namespace HotelListing.Core.IRepository
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginUserDTO userDTO);
        Task<string> CreateToken();
    }
}
