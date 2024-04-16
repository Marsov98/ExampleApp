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
    public UserRepository(ExampleAppDbContext db)
    {
        _db = db;
    }
    public void AddUser(User user)
    {
        _db.Users.Add(user);
    }

    public void DeleteUser(int id)
    {
        var user = _db.Users.Find(id);
        _db.Users.Remove(user);
    }

    public async Task<User> GetUserById(int id)
    {
        return await _db.Users.FindAsync(id);
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _db.Users.ToListAsync();
    }

    public void UpdateUserName(User user)
    {
        _db.Users.Update(user);
    }
}
