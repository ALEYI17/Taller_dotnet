using System;
using Grpc.Net.Client;

namespace DatosClient
{
    class Program
    {
        static async Task Main(String[] args)
        {
            // La dirección del servidor gRPC
            using var channel = GrpcChannel.ForAddress("http://localhost:5243");

            // Crear el cliente gRPC
            var client = new DataBuff.DataBuffClient(channel);

            // Ejemplo de llamada al método del servicio gRPC
            var response = await client.ListUsusarioAsync(new GetAllUsersRequest());

            // Manejar la respuesta
            foreach (var usuario in response.Usuarios)
            {
                Console.WriteLine($"ID: {usuario.Id}, Nombre: {usuario.Nombre}, Email: {usuario.Email}");
            }

            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }

    }
}