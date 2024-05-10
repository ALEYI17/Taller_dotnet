using System;
using System.Diagnostics;
using System.Threading.Tasks;
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

            // Realizar pruebas de carga con diferentes cantidades de solicitudes
            int[] requests = { 10, 50, 100, 150 };

            foreach (int numRequests in requests)
            {
                Console.WriteLine($"Realizando {numRequests} solicitudes...");

                // Medir el tiempo de respuesta
                Stopwatch stopwatch = Stopwatch.StartNew();

                // Lista para almacenar las respuestas
                var responses = new List<GetAllUsersResponse>();

                for (int i = 0; i < numRequests; i++)
                {
                    // Ejemplo de llamada al método del servicio gRPC
                    var response = await client.ListUsusarioAsync(new GetAllUsersRequest());
                    responses.Add(response);
                }

                stopwatch.Stop();
                Console.WriteLine($"Tiempo total para {numRequests} solicitudes: {stopwatch.ElapsedMilliseconds} ms");

                // Imprimir los usuarios
                Console.WriteLine($"Usuarios obtenidos:");

                foreach (var response in responses)
                {
                    foreach (var usuario in response.Usuarios)
                    {
                        Console.WriteLine($"Nombre: {usuario.Nombre}, Email: {usuario.Email}");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine("Pruebas de carga completadas. Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
