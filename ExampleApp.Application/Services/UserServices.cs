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
    public async Task<bool> IsExistsUser(User user)
    {
        var u = await _db.Users.Where(u => u.Login == user.Login).FirstOrDefaultAsync();

        if (u != null) return true;
        else return false;
    }

    public async Task<bool> IsFill(User user)
    {
        bool isCurrent = true;

        if (user.Name.Length == 0) isCurrent = false;
        if (user.Login.Length == 0) isCurrent = false;
        if (user.Password.Length == 0) isCurrent = false;
        if (user.RoleId <= 0) isCurrent = false;

        return isCurrent;
    }

    public async Task<int> FindUserId(User user)
    {
        var u = await _db.Users.Where(u => u.Login == user.Login).FirstAsync();
        return u.Id;
    }

    public async Task<User> Login(User user)
    {
        return await _db.Users.Where(u => u.Login == user.Login && u.Password == user.Password).FirstOrDefaultAsync();
    }
}
