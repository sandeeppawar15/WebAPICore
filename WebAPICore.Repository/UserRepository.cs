using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICore.Entity;

namespace WebAPICore.Repository
{
    public class UserRepository : IUserRepository
    {
        internal DbContext _dbContext;
        public UserRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> Get()
        {
            return _dbContext.Database.Include(u => u.UserType).OrderByDescending(u => u.Id).ToList();
        }
    }
}
