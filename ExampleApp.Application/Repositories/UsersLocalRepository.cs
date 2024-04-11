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

    /// <summary>
    /// Возращает пользователя с указанным Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<User> GetUserById(int id)
    {
        return Users.Where(u => u.Id == id).FirstOrDefault();
    }

    /// <summary>
    /// Добавляет нового пользователя
    /// </summary>
    /// <param name="user"></param>
    public void AddUser(User user)
    {
        (Users as List<User>).Add(user);
    }

    /// <summary>
    /// Обновляет имя пользователя
    /// </summary>
    /// <param name="user"></param>
    public void UpdateUserName(User user)
    {
        foreach (var item in Users)
        {
            if (item.Id == user.Id) item.Name = user.Name;
        }
    }
    
    /// <summary>
    /// Удаляет пользователя с указанным Id
    /// </summary>
    /// <param name="id"></param>
    public void DeleteUser(int id)
    {
        var delete = (Users as List<User>).Find(u => u.Id == id);

        (Users as List<User>).Remove(delete);
    }
}
