using CatchThemAll.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CatchThemAll
{
    class Program
    {
        static void Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args).UseStartup<Startup>();

            var captureAppService = host.Services.GetRequiredService<ICaptureAppService>();

            Execute(captureAppService);
        }

        static void Execute(ICaptureAppService captureAppService)
        {
            Console.WriteLine("Informe os movimentos do Ash");
            var moves = Console.ReadLine();

            try
            {
                var caughtPokemons = captureAppService.Capture(moves);
           
                Console.WriteLine();
                Console.WriteLine($"Pokémons capturados: {caughtPokemons}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }            
        }
    }
}
