using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnlockCells.Interfaces;
using UnlockCells.Models;

namespace UnlockCells.Repositories
{
    public class UserRepository : IUser
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<User> Users => _appDbContext.Users;

        public User GetUserById(int userId) => _appDbContext.Users.FirstOrDefault(p => p.Id == userId);

    }
}