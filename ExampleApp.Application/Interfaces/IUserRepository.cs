using ExampleApp.Domen.Models;

namespace ExampleApp.Application.Interfaces;
public interface IUserRepository
{

    Task<IEnumerable<User>> GetUsersAsync();
    Task<User> GetUserByIdAsync(int id);

    void AddUser(User user);
     
    void UpdateUser(User user);

    void DeleteUser(int id);

}
