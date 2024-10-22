using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackspotAI;
using StackspotAI.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace StackspotAI.Samples.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            var stackSpotAI = host.Services.GetRequiredService<StackspotAIFacade>();

            Console.WriteLine("Creating a new Knowledge Source...");
            var result = await stackSpotAI.CreateKnowledgeSourceAsync("Sample Knowledge Source", "This is a sample knowledge source created from the console app.");

            if (result.IsSuccess)
            {
                Console.WriteLine($"Knowledge Source created successfully. ID: {result.Value.Id}");
            }
            else
            {
                Console.WriteLine($"Failed to create Knowledge Source. Error: {result.Error}");
            }

            await host.RunAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddStackspotAI(hostContext.Configuration);
                });
    }
}
