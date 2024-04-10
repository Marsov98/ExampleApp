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
        return  Ok(await _repo.GetUsers());
    }

    // GET api/<UsersController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<UsersController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<UsersController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<UsersController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
