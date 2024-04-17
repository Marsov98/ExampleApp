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

        // GET: api/<UsersController>/Login
        [HttpGet ("Login")]
        public async Task<ActionResult<IEnumerable<User>>> Login(string login, string password)
        {
            var user = await _service.LoginAsync(new User { Login=login, Password=password });

            if(user != null) return Ok(user);
            return BadRequest("Такого пользователя нет");
        }
    }

<<<<<<< HEAD
=======
    // GET: api/<UsersController>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
    {
        return Ok(await _repo.GetUsers());
    }

    // GET api/<UsersController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser([FromRoute] int id)
    {
        return await _repo.GetUserById(id); 
    }

    // POST api/<UsersController>/AddUser
    [HttpPost]
    public void Post([FromBody] User user)
    {
        // valid


        _repo.AddUser(user);
    }

    // PUT api/<UsersController>/UpdateUser
    [HttpPut("UpdateUser")]
    public void Put([FromBody] User user)
    {
        _repo.UpdateUserName(user);
    }

    // DELETE api/<UsersController>/DeleteUser/5
    [HttpDelete("DeleteUser/{id}")]
    public void Delete([FromRoute] int id)
    {
        _repo.DeleteUser(id);
    }


    // POST api/User/checkname
    [HttpPost("checkname")]
    public IActionResult CheckName([FromBody] string name)
    {
        if (name == "admin")
            return BadRequest("admin not allowed");

        return Ok(name);
        //return name == "admin" ? BadRequest("admin") : Ok();
    }



>>>>>>> 8aebd21b6e517445a9a00f2d1cbdcf41e4a95fef
}
