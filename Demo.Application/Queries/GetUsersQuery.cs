using Demo.Application.Dtos;
using MediatR;

namespace Demo.Application.Queries
{
    public class GetUsersQuery : IRequest<IEnumerable<UserDto>>
    {
    }
}
