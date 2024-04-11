using ExampleApp.Application.Interfaces;
using ExampleApp.Application.Repositories;
using ExampleApp.Domen.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{

    private readonly IUserRepository _repo;

    public UsersController(IUserRepository repo)
    {
        _repo = repo;
    }

    // GET: api/<UsersController>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
    {
        return Ok(await _repo.GetUsers());
    }

    // GET api/<UsersController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _repo.GetUserById(id);

        if(user != null) return Ok(user);
        else return BadRequest();
    }

    // POST api/<UsersController>/AddUser
    [HttpPost]
    public void Post([FromBody] User user)
    {
        _repo.AddUser(user);
    }

    // PUT api/<UsersController>/UpdateUser
    [HttpPut("UpdateUser")]
    public void Put([FromBody] User user)
    {
        _repo.UpdateUserName(user);
    }

    // DELETE api/<UsersController>/DeleteUser/5
    [HttpDelete("DeleteUser")]
    public void Delete(int id)
    {
        _repo.DeleteUser(id);
    }
}
