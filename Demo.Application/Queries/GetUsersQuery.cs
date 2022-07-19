using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Application.Dtos;
using MediatR;

namespace Demo.Application.Queries
{
    public class GetUsersQuery : IRequest<IEnumerable<UserDto>>
    {
    }
}
