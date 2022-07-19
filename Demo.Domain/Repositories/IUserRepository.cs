﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Domain.Entities;
using Demo.Domain.SeedWork;

namespace Demo.Domain.Repositories
{
    public interface IUserRepository
    {
        IUnitOfWork UnitOfWork { get; }

        Task<User> GetUserAsync(int id);

        Task<IEnumerable<User>> GetUsersAsync();

        Task<User> CreateUserAsync(User user);

        void UpdateUser(User user);

        void DeleteUser(User user);
    }
}
