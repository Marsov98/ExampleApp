using ExampleApp.Domen.Models;
using FluentValidation;
using System.Net.Http.Json;

public class NameValidator : AbstractValidator<User>
{
    private readonly HttpClient _httpClient;
    public NameValidator(HttpClient httpClient)
    {
        _httpClient = httpClient;

        RuleFor(m => m.Name)
            .MustAsync(async (name, cancellation) => await IsNameValidAsync(name))
            .WithMessage("Имя уже используется.");
    }

    private async Task<bool> IsNameValidAsync(string name)
    {
        var response = await _httpClient.PostAsJsonAsync("https://localhost:7032/api/Users/checkname",name);
        Console.WriteLine(response.IsSuccessStatusCode);

        if (!response.IsSuccessStatusCode)
        {
            // Попытка прочитать сообщение об ошибке из ответа
            var errorContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Ошибка: {errorContent}");
            return false;
        }

        return response.IsSuccessStatusCode;
    }
}


