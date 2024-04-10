using ExampleApp.Application.Interfaces;
using ExampleApp.Domen.Models;

namespace ExampleApp.Application.Repositories;

public class UsersLocalRepository : IUserRepository
{

    public IEnumerable<User> Users { get; set; } = new List<User>();

    public UsersLocalRepository()
    {
        (Users as List<User>).Add(new User() { Id = 1, Name = "user1" });
        (Users as List<User>).Add(new User() { Id = 2, Name = "user2" });
    }


    /// <summary>
    /// Возвращает все пользователей из локальной коллекции
    /// </summary>
    /// <returns> IEnumerable<User> </returns>
    public async Task<IEnumerable<User>> GetUsers()
    {
        return Users;
    }
}
