using ExampleApp.Application.Interfaces;
using ExampleApp.Application.Repositories;
using ExampleApp.Application.Service;
using ExampleApp.Application.Services;
using ExampleApp.Domen;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddDbContext<ExampleAppDbContext>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleServices, RoleServices>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(p => p.AllowAnyHeader().AllowAnyOrigin());


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
