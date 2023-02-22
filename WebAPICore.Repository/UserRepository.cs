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
            if (userId > 0)
            {
                return await _webAPICoreDbContext.User.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<User> UpdateUser(User user)
        {
            var result = await _webAPICoreDbContext.User.FirstOrDefaultAsync(u => u.UserId == user.UserId);
            if (result != null)
            {
                result.UserName = user.UserName;
                result.Status = user.Status;
                result.UpdatedOn = DateTime.Now;
                result.FirstName = user.FirstName;
                result.LastName = user.LastName;

                await _webAPICoreDbContext.SaveChangesAsync();
                return result;

            }
            return null;
        }
    }
}
