using Demo.Domain.Entities;
using Demo.Domain.Repositories;
using Demo.Domain.SeedWork;
using Demo.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public UserRepository(UsersContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User> GetUserAsync(int id)
        {
            var user = await _context.Users
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return user;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var result = await _context.Users.AddAsync(user);

            return result.Entity;
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;

            _context.Update(user);
        }

        public void DeleteUser(User user)
        {
            _context.Entry(user).State = EntityState.Deleted;

            _context.Users.Remove(user);
        }
    }
}
