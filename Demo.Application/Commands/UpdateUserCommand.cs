using Demo.Application.Dtos;
using MediatR;

namespace Demo.Application.Commands
{
    public class UpdateUserCommand : IRequest<UserDto>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int RoleId { get; set; }

        public UpdateUserCommand(int id, string firstName, string lastName, string email, int roleId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            RoleId = roleId;
        }
    }
}
