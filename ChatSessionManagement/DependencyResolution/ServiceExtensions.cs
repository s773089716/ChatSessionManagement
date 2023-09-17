using ChatSessionManagement.Core.Repositories;
using ChatSessionManagement.Core.Services;
using ChatSessionManagement.Repositories.InMemoryRepositories;
using ChatSessionManagement.Services;

namespace ChatSessionManagement.DependencyResolution
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, ILoggerFactory _loggerFactory)
        {
            services.AddScoped<IAgentRepository, AgentRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IChatSessionRepository, ChatSessionRepository>();
            services.AddScoped<IChatSessionService, ChatSessionService>();
            //services.AddScoped<IScopedProcessingService, DefaultScopedProcessingService>();

            return services;
        }
    }
}
