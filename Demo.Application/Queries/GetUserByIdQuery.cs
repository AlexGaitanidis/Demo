using Demo.Application.Dtos;
using MediatR;

namespace Demo.Application.Queries
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public int Id { get; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
