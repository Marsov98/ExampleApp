using ExampleApp.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleApp.Application.Interfaces;

public interface IRoleRepository
{
    public Task<IEnumerable<Role>> GetRolesAsync();
    public Task<Role> GetRoleByIdAsync(int id);
    public void AddRole(Role role);
    public void UpdateRole (Role role);
    public void DeleteRole(int id);
}
