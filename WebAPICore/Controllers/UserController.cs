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


        //[HttpGet]
        //public IEnumerable<User> Get()
        //{
        //    if (_userRepository.Get() == null)
        //    {
        //        return (IEnumerable<User>)NotFound();
        //    }
        //    return _userRepository.Get();
        //}

        //[HttpGet("{id}")]
        //public User Get(int id)
        //{
        //    return _userRepository.Get(id);
        //}


        //[HttpPost]
        //public int Post(User user)
        //{
        //    return _userRepository.Add(user);
        //}



        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            if (id > 0)
            {
                var result = await _userRepository.GetUser(id);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _userRepository.GetUsers();
            if (result.Count() > 0)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, User user)
        {

            var userArr = await _userRepository.GetUser(id);
            if (userArr != null)
            {
                var result = await _userRepository.UpdateUser(user);
                return Ok(result);
            }
            return NotFound($"User with Id = {id} not found");
        }

    }

}
