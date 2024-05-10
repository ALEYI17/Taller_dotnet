using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Define some dummy data for users
var users = Enumerable.Range(1, 10).Select(id =>
    new Usuario
    {
        Id = id,
        Nombre = $"User{id}",
        Email = $"user{id}@example.com"
    }).ToList();

app.MapGet("/GetUsuario/{id}", (HttpContext context, int id) =>
{
    var user = users.FirstOrDefault(u => u.Id == id);
    if (user != null)
    {
        return Results.Ok(user);
    }
    else
    {
        return Results.NotFound($"User with id {id} not found.");
    }
})
.WithName("GetUsuario")
.WithOpenApi();


app.MapGet("/getCliDB", async (HttpContext context) =>
{
    using var client = new HttpClient();
    var response = await client.GetAsync("http://localhost:5069/getCliDB"); // Assuming the endpoint is local
    if (response.IsSuccessStatusCode)
    {
        var content = await response.Content.ReadAsStringAsync();
        return Results.Ok(content);
    }
    else
    {
        return Results.NotFound();
    }
})
.WithName("GetCliDB")
.WithOpenApi();



app.Run();

public partial class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Email { get; set; } = null!;
}
