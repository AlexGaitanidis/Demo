using Demo.Application.Commands;
using Demo.Domain.Repositories;
using MediatR;

namespace Demo.Application.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserAsync(request.Id);

            if (user == null)
                return false;

            _userRepository.DeleteUser(user);

            await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
