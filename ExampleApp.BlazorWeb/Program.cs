using ExampleApp.Application.Interfaces;
using ExampleApp.Application.Repositories;
using ExampleApp.BlazorWeb.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<HttpClient>(sp =>
    new HttpClient
    {
        BaseAddress = new Uri("https://localhost:7032")
    });
builder.Services.AddSingleton<IUserRepository, UsersLocalRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
