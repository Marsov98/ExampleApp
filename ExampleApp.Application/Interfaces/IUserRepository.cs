using ExampleApp.Domen.Models;

namespace ExampleApp.Application.Interfaces;
public interface IUserRepository
{

    Task<IEnumerable<User>> GetUsers();
    Task<User> GetUserById(int id);

    void AddUser(User user);
     
    void UpdateUserName(User user);

    void DeleteUser(int id);

}
