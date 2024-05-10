using Datos.model;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DbPruebaContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/getCliDB", async (DbPruebaContext dbContext) =>
{
    // Assuming Usuario is your model representing clients
    var clients = await dbContext.Usuarios.ToListAsync(); // Fetch clients from the database
    return clients;
})
.WithName("GetClients")
.WithOpenApi();

app.Run();
