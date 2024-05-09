var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/users", () =>
{
    // La dirección del servidor gRPC
    using var channel = GrpcChannel.ForAddress("http://localhost:5243");

    // Crear el cliente gRPC
    var client = new DataBuff.DataBuffClient(channel);

    // Ejemplo de llamada al método del servicio gRPC
    var response = await client.ListUsusarioAsync(new GetAllUsersRequest());

    return response;
});

app.Run();
