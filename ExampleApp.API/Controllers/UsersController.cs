using ExampleApp.Application.Interfaces;
using ExampleApp.Domen.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApp.API.Controllers
{
    [Route("api/[controller]")]
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

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            return Ok(await _repo.GetUsers());
        }

        // GET: api/<UsersController>/5
        [HttpGet ("{id}")]
        public async Task<ActionResult<User>> GetUser([FromRoute] int id)
        {
            return Ok(await _repo.GetUserById(id));
        }

        // POST: api/<UsersController>/Post
        [HttpPost ("/Post")]
        public async Task<ActionResult> AddUser(User user)
        {
            if ( await _service.IsExistsUser(user) == null)
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

        // PUT: api/<UsersController>/Put
        [HttpPut("/Put")]
        public async Task<ActionResult> UpdateUser(User user)
        {
            var update = await _service.IsExistsUser(user);

            if (update != null)
            {
                if (await _service.IsFill(user))
                {
                    (update.Password, update.Name, update.RoleId) = (user.Password, user.Name, user.RoleId);

                    _repo.UpdateUser(update);
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

        // DELETE: api/<UsersController>/Delete
        [HttpDelete("/Delete")]
        public async Task<ActionResult> DeleteUser(string login)
        {
            var delete = await _service.IsExistsUser(new User { Login = login} );
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

        // GET: api/<UsersController>/Login
        [HttpGet ("/Login")]
        public async Task<ActionResult<IEnumerable<User>>> Login(string login, string password)
        {
            var user = _service.Login(new User { Login=login, Password=password });

            if(user != null) return Ok(user);
            return BadRequest("Такого пользователя нет");
        }
    }
}
