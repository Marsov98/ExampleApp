using ExampleApp.Application.Interfaces;
using ExampleApp.Domen;
using ExampleApp.Domen.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ExampleApp.Application.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ExampleAppDbContext _db;
    private readonly ILogger<UserRepository> _logger;
    public UserRepository(ExampleAppDbContext db, ILogger<UserRepository> logger)
    {
        _db = db;
        _logger = logger;
    }

    /// <summary>
    /// Добавить нового пользователя
    /// </summary>
    /// <param name="user"></param>
    public void AddUser(User user)
    {
        _db.Users.Add(user);
        try
        {
            _db.SaveChanges();
            _logger.LogInformation("Новый пользователь успешно сохранён");
        }
        catch (Exception)
        {
            _logger.LogError("Ошибка сохранения нового пользователя");
        }
    }

   /// <summary>
   /// Удалить пользователя
   /// </summary>
   /// <param name="id"></param>
    public void DeleteUser(int id)
    {
        var user = _db.Users.Find(id);
        _db.Users.Remove(user);
        try
        {
            _db.SaveChanges();
            _logger.LogInformation("Пользователь успешно удалён");
        }
        catch (Exception)
        {
            _logger.LogError("Ошибка удаления пользователя");
        }
    }

    /// <summary>
    /// Получить пользователя по Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _db.Users.Include(u => u.Role.Name).Where(u => u.Id == id).FirstOrDefaultAsync();
    }

    /// <summary>
    /// Получить всех пользователей
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await _db.Users.Include(u => u.Role.Name).ToListAsync();
    }

    /// <summary>
    /// Обновить пользователя
    /// </summary>
    /// <param name="user"></param>
    public void UpdateUser(User user)
    {
        _db.Users.Update(user);
        try
        {
            _db.SaveChanges();
            _logger.LogInformation("Пользователь успешно обновлён");
        }
        catch (Exception)
        {
            _logger.LogError("Ошибка обновления пользователя");
        }
    }
}
