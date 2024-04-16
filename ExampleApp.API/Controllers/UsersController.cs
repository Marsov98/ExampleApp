using ExampleApp.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserRepository repo, ILogger<UsersController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

    }
}
