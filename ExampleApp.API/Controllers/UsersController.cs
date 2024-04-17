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



}
