using System.ComponentModel.DataAnnotations;

namespace ExampleApp.Domen.Models;

public class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Введите имя")]
    public string Name { get; set; }
}

