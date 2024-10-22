using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackSpotAI.Interfaces;
using StackSpotAI.Services;
using StackSpotAI.Options;
using StackSpotAI.Mediator;

namespace StackSpotAI.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddStackSpotAI(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<StackSpotAIOptions>(configuration.GetSection(StackSpotAIOptions.SectionName));

            services.AddHttpClient<IStackSpotHttpClient, StackSpotHttpClient>();
            services.AddSingleton<ITokenService, TokenService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IKnowledgeSourceRepository, KnowledgeSourceRepository>();
            services.AddScoped<IQuickCommandRepository, QuickCommandRepository>();

            services.AddScoped<IKnowledgeSourceService, KnowledgeSourceService>();
            services.AddScoped<IQuickCommandService, QuickCommandService>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(StackSpotAIFacade).Assembly));

            services.AddScoped<StackSpotAIFacade>();

            return services;
        }
    }
}
