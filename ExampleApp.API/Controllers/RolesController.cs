using ExampleApp.Application.Interfaces;
using ExampleApp.Domen.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApp.API.Controllers
{
    [Route("api/Roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleRepository _repo;
        private readonly ILogger<RolesController> _logger;
        private readonly IRoleServices _service;
        public RolesController(IRoleRepository repo, IRoleServices service, ILogger<RolesController> logger)
        { 
            _repo = repo;
            _logger = logger;
            _service = service;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetAllUsers()
        {
            return Ok(await _repo.GetRolesAsync());
        }

        // GET api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            var role = await _repo.GetRoleByIdAsync(id);
            if (role != null)
            {
                return Ok(role);
            }
            else
            {
                return BadRequest("Такой роли не существует");
            }
        }

        // POST api/Roles/Post
        [HttpPost("Post")]
        public async Task<ActionResult> PostRole(Role role)
        {
            if (await _service.IsExistsRoleAsync(role) == null)
            {
                if (await _service.IsFill(role))
                {
                    _repo.AddRole(role);
                    return Ok("Роль успешно добавлена");
                }
                else
                {
                    _logger.LogError("Не все поля были заполнены");
                    return BadRequest("Не все поля были заполнены");
                }
            }
            else
            {
                _logger.LogError("Роль с таким названием уже существует");
                return BadRequest("Роль с таким названием уже существует");
            }
        }

        // PUT api/Roles/Put
        [HttpPut("Put")]
        public async Task<ActionResult> PutRole(Role role)
        {
            if (await _repo.GetRoleByIdAsync(role.Id) != null)
            {
                if (await _service.IsFill(role))
                {
                    if (await _service.IsExistsRoleAsync(role) == null)
                    {
                        _repo.UpdateRole(role);
                        return Ok("Роль успешно обновлена");
                    }
                    else
                    {
                        _logger.LogError("Роль с таким название уже существует");
                        return BadRequest("Роль с таким название уже существует");
                    }
                }
                else
                {
                    _logger.LogError("Не все поля были заполнены");
                    return BadRequest("Не все поля были заполнены");
                }
            }
            else
            {
                _logger.LogError("Роль не существует");
                return BadRequest("Роль не существует");
            }
            
        }

        // DELETE api/Roles/Delete
        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteRole(string name)
        {
            var delete = await _service.IsExistsRoleAsync(new Role { Name = name });
            if (delete != null)
            {
                _repo.DeleteRole(delete.Id);
                return Ok("Роль успешно удалена");
            }
            else
            {
                _logger.LogError("Роли с таким названием не существует");
                return BadRequest("Роли с таким название не существует");
            }
        }
    }
}
