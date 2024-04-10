using ExampleApp.Domen.Models;

namespace ExampleApp.Application.Interfaces;
public interface IUserRepository
{

    Task<IEnumerable<User>> GetUsers();   

}
