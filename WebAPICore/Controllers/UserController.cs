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

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            try
            {
                if (id > 0)
                {
                    var result = await _userRepository.GetUser(id);
                    if (result == null)
                    {
                        return NotFound();
                    }
                    return Ok(result);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await _userRepository.GetUsers();
                if (result.Count() < 0)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }


        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<User>> Put(int id, User user)
        {

            try
            {
                if (id != user.UserId)
                    return BadRequest("User ID mismatch");

                var userToUpdate = await _userRepository.GetUser(id);

                if (userToUpdate == null)
                    return NotFound($"User with Id = {id} not found");

                return await _userRepository.UpdateUser(user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<User>> Delete(int id)
        {

            try
            {
                var userDelete = await _userRepository.GetUser(id);

                if (userDelete == null)
                {
                    return NotFound($"User with Id = {id} not found");
                }

                return await _userRepository.DeleteUser(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }


        [HttpPost]
        public async Task<ActionResult<User>> Add(User user)
        {

            try
            {
                if (User == null)
                    return BadRequest();

                var userToAdd = await _userRepository.AddUser(user);
                return CreatedAtAction(nameof(Get),
                new { id = userToAdd.UserId }, userToAdd);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new user record");
            }
        }
    }

}
