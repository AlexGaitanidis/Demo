using Demo.Domain.Entities;
using Demo.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.DataAccess
{
    public class UsersContext : DbContext, IUnitOfWork
    {
        public UsersContext(DbContextOptions<UsersContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                FirstName = "Alexandros",
                LastName = "G",
                Email = "alexandros.g@mail.com",
                RoleId = 1

            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 2,
                FirstName = "Despoina",
                LastName = "C",
                Email = "despoina.c@mail.com",
                RoleId = 2

            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 3,
                FirstName = "Crysostomos",
                LastName = "T",
                Email = "chrysostomos.t@mail.com",
                RoleId = 2

            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 4,
                FirstName = "Thomas",
                LastName = "Z",
                Email = "thomas.z@mail.com",
                RoleId = 2

            });

            modelBuilder.Entity<UserRole>().HasData(new UserRole
            {
                Id = 1,
                Name = "Admin"
            });

            modelBuilder.Entity<UserRole>().HasData(new UserRole
            {
                Id = 2,
                Name = "Member"
            });

        }
    }
}
