using System;
using System.Net;
using System.Threading.Tasks;
using RabbitMQ.Stream.Client;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            var config = new StreamSystemConfig
            {
                UserName = "guest",
                Password = "guest",
                Endpoints = new[] { new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5552) }
            };

            var system = await StreamSystem.Create(config);

            string streamName = "pecas_stream";

            var exists = await system.StreamExists(streamName);

            if (!exists)
            {
                await system.CreateStream(new StreamSpec(streamName)
                {
                    MaxLengthBytes = 10_000_000 // (10 MB)
                });

                Console.WriteLine($"✅ Stream '{streamName}' criada com sucesso.");
            }
            else
            {
                Console.WriteLine($"ℹ️ Stream '{streamName}' já existe.");
            }

            await system.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Erro ao criar o stream: {ex.Message}");
        }

        Console.WriteLine("Pressiona qualquer tecla para sair...");
        Console.ReadKey();
    }
}

