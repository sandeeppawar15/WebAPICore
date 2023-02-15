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
        private DbContext _dbContext;

        private WebAPICoreDbContext _webAPICoreDbContext;

        public UserRepository(DbContext dbContext, WebAPICoreDbContext webAPICoreDbContext)
        {
            _dbContext = dbContext;
            _webAPICoreDbContext = webAPICoreDbContext;
        }

        //public int Add(User user)
        //{
        //    _dbContext.Add(user);
        //    var result = _dbContext.SaveChanges();
        //    return result;
        //}

        //public List<User> Get()
        //{
        //    var users = _webAPICoreDbContext.Set<User>().ToList();
        //    //var users = _dbContext.Set<User>().ToList();
        //    return users;
        //}



        //public User? Get(int id)
        //{
        //    var user = _dbContext.Find<User>(id);
        //    if (user==null)
        //    {
        //        return null;
        //    }
        //    return user;
        //}

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _webAPICoreDbContext.Set<User>().ToListAsync();
        }

        public async Task<User> GetUser(int userId)
        {
            return await _webAPICoreDbContext.User.Where(x => x.UserId == userId).FirstOrDefaultAsync();
        }
    }
}
