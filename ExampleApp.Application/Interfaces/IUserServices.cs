using ExampleApp.Domen.Models;

namespace ExampleApp.Application.Interfaces;

public interface IUserServices
{
    public Task<User?> IsExistsUserAsync(User user);
    public Task<bool> IsFill(User user);
    public Task<User> LoginAsync(User user);
}
