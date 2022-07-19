using System.Net.Http.Json;
using Demo.Application.Dtos;
using Demo.UI.Services.Contracts;

namespace Demo.UI.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _client;

        public UserService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = await _client.GetFromJsonAsync<IEnumerable<UserDto>>("api/Users");

            return users;
        }
    }
}
