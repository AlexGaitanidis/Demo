using Demo.Application.Dtos;

namespace Demo.UI.Services.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsers();
    }
}
