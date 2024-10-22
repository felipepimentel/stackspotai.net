using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackspotAI.Interfaces;
using StackspotAI.Services;
using StackspotAI.Options;
using StackspotAI.Mediator;
using StackspotAI.Repositories;

namespace StackspotAI.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddStackspotAI(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<StackspotAIOptions>(configuration.GetSection("StackspotAI"));

            services.AddHttpClient<IStackspotHttpClient, StackspotHttpClient>();
            services.AddSingleton<ITokenService, TokenService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IKnowledgeSourceRepository, KnowledgeSourceRepository>();
            services.AddScoped<IQuickCommandRepository, QuickCommandRepository>();

            services.AddScoped<IKnowledgeSourceService, KnowledgeSourceService>();
            services.AddScoped<IQuickCommandService, QuickCommandService>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(StackspotAIFacade).Assembly));

            services.AddScoped<StackspotAIFacade>();

            return services;
        }
    }
}
