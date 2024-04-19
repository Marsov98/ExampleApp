using ExampleApp.Application.Interfaces;
using ExampleApp.Domen.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApp.API.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IUserServices _service;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserRepository repo, IUserServices service, ILogger<UsersController> logger)
        {
            _repo = repo;
            _logger = logger;
            _service = service;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            return Ok(await _repo.GetUsersAsync());
        }

        // GET: api/Users/5
        [HttpGet ("{id}")]
        public async Task<ActionResult<User>> GetUser([FromRoute] int id)
        {
            var user = await _repo.GetUserByIdAsync(id);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest("Такого пользователя не существует");
            }
        }

        // POST: api/Users/Post
        [HttpPost ("Post")]
        public async Task<ActionResult> AddUser(User user)
        {
            if ( await _service.IsExistsUserAsync(user) == null)
            {
                if (await _service.IsFill(user))
                {
                    _repo.AddUser(user);
                    return Ok("Пользователь успешно добавлен");
                }
                else
                {
                    _logger.LogError("Не все поля были заполнены");
                    return BadRequest("Не все поля были заполнены");
                }
            }
            else
            {
                _logger.LogError("Пользователь с таким логином уже существует");
                return BadRequest("Пользователь с таким логином уже существует");
            }
        }

        // PUT: api/Users/Put
        [HttpPut("Put")]
        public async Task<ActionResult> UpdateUser(User user)
        {
            var update = await _service.IsExistsUserAsync(user);
            if (update != null)
            {
                if (await _service.IsFill(user))
                {
                    (update.Name, update.Password, update.RoleId) = (user.Name, user.Password, user.RoleId);
                    _repo.UpdateUser(user);
                    return Ok("Пользователь успешно обновлён");
                }
                else
                {
                    _logger.LogError("Не все поля были заполнены");
                    return BadRequest("Не все поля были заполнены");
                }
            }
            else
            {
                _logger.LogError("Пользователь с таким логином не существует");
                return BadRequest("Пользователь с таким логином не существует");
            }
        }

        // DELETE: api/Users/Delete
        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteUser(string login)
        {
            var delete = await _service.IsExistsUserAsync(new User { Login = login} );
            if (delete != null)
            {
                _repo.DeleteUser(delete.Id);
                return Ok("Пользователь успешно удалён");
            }
            else
            {
                _logger.LogError("Пользователь с таким логином не существует");
                return BadRequest("Пользователь с таким логином не существует");
            }
        }

        // GET: api/Users/Login
        [HttpGet ("Login")]
        public async Task<ActionResult<IEnumerable<User>>> Login(string login, string password)
        {
            var user = await _service.LoginAsync(new User { Login=login, Password=password });

            if(user != null) return Ok(user);
            return BadRequest("Такого пользователя нет");
        }
    }


}
