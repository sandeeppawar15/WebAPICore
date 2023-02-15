using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICore.Entity;

namespace WebAPICore.Repository
{
    public interface IUserRepository
    {
        //List<User> Get();
        //User Get(int id);

        //int Add(User user);

        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        //Task<User> AddUser(User user);
        //Task<User> UpdateUser(User user);
        //void DeleteUser(int userId);
    }
}
