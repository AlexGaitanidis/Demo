using Demo.Application.Dtos;
using Demo.UI.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace Demo.UI.Pages
{
    public class UsersBase : ComponentBase
    {
        [Inject]
        public IUserService UserService { get; set; }

        public IEnumerable<UserDto> Users { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Users = await UserService.GetUsers();
        }
    }
}