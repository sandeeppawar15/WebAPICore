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
        //private DbContext _dbContext;

        private WebAPICoreDbContext _webAPICoreDbContext;

        public UserRepository(DbContext dbContext, WebAPICoreDbContext webAPICoreDbContext)
        {
            //_dbContext = dbContext;
            _webAPICoreDbContext = webAPICoreDbContext;
        }


        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _webAPICoreDbContext.User.ToListAsync();
        }

        public async Task<User> GetUser(int userId)
        {
            return await _webAPICoreDbContext.User.FirstOrDefaultAsync(x => x.UserId == userId);
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
                result.EmailId = user.EmailId;

                await _webAPICoreDbContext.SaveChangesAsync();
                return result;

            }
            return null;
        }

        public async void DeleteUser(int userId)
        {
            var result = await _webAPICoreDbContext.User.FirstOrDefaultAsync(u => u.UserId == userId);

            if (result != null)
            {
                _webAPICoreDbContext.User.Remove(result);
                await _webAPICoreDbContext.SaveChangesAsync();
            }
        }
    }
}

