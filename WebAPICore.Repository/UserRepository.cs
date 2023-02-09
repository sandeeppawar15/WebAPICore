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
            var users = _dbContext.Set<User>().ToList();
            return users;
        }



        public User? Get(int id)
        {
            var user = _dbContext.Find<User>(id);
            if (user==null)
            {
                return null;
            }
            return user;
        }

    
    }
}
