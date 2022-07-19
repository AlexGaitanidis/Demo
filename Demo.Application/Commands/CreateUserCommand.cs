using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Application.Dtos;
using Demo.Domain.Entities;
using MediatR;

namespace Demo.Application.Commands
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int RoleId { get; set; }

        public CreateUserCommand(string firstName, string lastName, string email, int roleId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            RoleId = roleId;
        }
    }
}
