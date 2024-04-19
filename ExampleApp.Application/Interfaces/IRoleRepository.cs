using ExampleApp.Domen.Models;

namespace ExampleApp.Application.Interfaces;

public interface IRoleRepository
{
    public Task<IEnumerable<Role>> GetRolesAsync();
    public Task<Role> GetRoleByIdAsync(int id);
    public void AddRole(Role role);
    public void UpdateRole (Role role);
    public void DeleteRole(int id);
}
