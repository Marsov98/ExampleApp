using ExampleApp.Application.Interfaces;
using ExampleApp.Application.Repositories;
using ExampleApp.Domen;
using ExampleApp.Domen.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ExampleApp.Application.Service;

public class UserServices : IUserServices
{
    private readonly ExampleAppDbContext _db;
    public UserServices(ExampleAppDbContext db)
    {
        _db = db;
    }

    /// <summary>
    /// Проверка наличия пользователя
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public async Task<User?> IsExistsUserAsync(User user)
    {
        return await _db.Users.Where(u => u.Login == user.Login).FirstOrDefaultAsync();
    }

    /// <summary>
    /// Проверка заполненности полей
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public async Task<bool> IsFill(User user)
    {
        bool isCurrent = true;

        if (user.Name.Length == 0) isCurrent = false;
        if (user.Login.Length == 0) isCurrent = false;
        if (user.Password.Length == 0) isCurrent = false;
        if (user.RoleId <= 0) isCurrent = false;

        return isCurrent;
    }

    /// <summary>
    /// Авторизация пользователя
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public async Task<User> LoginAsync(User user)
    {
        return await _db.Users.Where(u => u.Login == user.Login && u.Password == user.Password).FirstOrDefaultAsync();
    }
}
