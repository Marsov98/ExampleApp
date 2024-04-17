using System.ComponentModel.DataAnnotations;

namespace ExampleApp.Domen.Models;

public class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Введите имя")]
    public string Name { get; set; }

    public string Login { get; set; }
    public string Password { get; set; }
    public int RoleId { get; set; }
    public Role? Role { get; set; }
}

