using ExampleApp.Application.Interfaces;
using ExampleApp.Domen;
using ExampleApp.Domen.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleApp.Application.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly ExampleAppDbContext _db;
    private readonly ILogger<RoleRepository> _logger;

    public RoleRepository(ExampleAppDbContext db, ILogger<RoleRepository> logger)
    {
        _db = db;
        _logger = logger;
    }

    /// <summary>
    /// Добавление роли
    /// </summary>
    /// <param name="role"></param>
    public void AddRole(Role role)
    {
        _db.Roles.Add(role);
        try
        {
            _db.SaveChanges();
            _logger.LogInformation("Роль добавлена");
        }
        catch (Exception)
        {
            _logger.LogError("Ошибка добавления роли");
        }
    }

    /// <summary>
    /// Удаление роли
    /// </summary>
    /// <param name="id"></param>
    public void DeleteRole(int id)
    {
        var role = _db.Roles.FirstOrDefault(r => r.Id == id);
        if (role != null)
        {
            _db.Roles.Remove(role);
            try
            {
                _db.SaveChanges();
                _logger.LogInformation("Роль удалена");
            }
            catch (Exception)
            {
                _logger.LogError("Ошибка удаления роли");
            }
        }
        else
        {
            _logger.LogError("Такой роли нет");
        }
    }

    /// <summary>
    /// Получение роли по Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Role> GetRoleByIdAsync(int id)
    {
        return await _db.Roles.FindAsync(id);
    }

    /// <summary>
    /// Получение всех ролей
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Role>> GetRolesAsync()
    {
        return await _db.Roles.ToListAsync();
    }

    /// <summary>
    /// Обновление роли
    /// </summary>
    /// <param name="role"></param>
    public void UpdateRole(Role role)
    {
        _db.Roles.Update(role);
        try
        {
            _db.SaveChanges();
            _logger.LogInformation("Роль успешно обновлён");
        }
        catch (Exception)
        {
            _logger.LogError("Ошибка обновления роли");
        }
    }
}
