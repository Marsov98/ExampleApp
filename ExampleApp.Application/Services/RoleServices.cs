using ExampleApp.Application.Interfaces;
using ExampleApp.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExampleApp.Domen;

namespace ExampleApp.Application.Services;

public class RoleServices : IRoleServices
{
    private readonly ExampleAppDbContext _db;
    public RoleServices(ExampleAppDbContext db)
    {
        _db = db;
    }

    /// <summary>
    /// Проверка наличия роли
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    public async Task<Role?> IsExistsRoleAsync(Role role)
    {
        return await _db.Roles.Where(r => r.Name == role.Name).FirstOrDefaultAsync();
    }
    
    /// <summary>
    /// Проверка заполненности полей
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    public async Task<bool> IsFill(Role role)
    {
        bool isCurrent = true;

        if (role.Name.Length == 0) isCurrent = false;

        return isCurrent;
    }
}
