using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICore.Entity;
using WebAPICore.Repository;

namespace WebAPICore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpGet]
        public IEnumerable<User> Get()
        {
            if (_userRepository.Get() == null)
            {
                return (IEnumerable<User>)NotFound();
            }
            return _userRepository.Get();
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _userRepository.Get(id);
        }


        [HttpPost]
        public int Post(User user) {         
             return _userRepository.Add(user);
        }

    }
}
