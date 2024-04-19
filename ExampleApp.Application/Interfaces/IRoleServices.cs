using ExampleApp.Domen.Models;

namespace ExampleApp.Application.Interfaces;

public interface IRoleServices
{
    public Task<Role?> IsExistsRoleAsync(Role role);
    public Task<bool> IsFill(Role role);
}
