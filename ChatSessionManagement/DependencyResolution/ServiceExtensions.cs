using ChatSessionManagement.BusinessLogic.BackgroundServiceScopes;
using ChatSessionManagement.BusinessLogic.Core.BackgroundServiceScopes;
using ChatSessionManagement.BusinessLogic.Core.Repositories;
using ChatSessionManagement.BusinessLogic.Core.Services;
using ChatSessionManagement.BusinessLogic.Repositories.InMemoryRepositories;
using ChatSessionManagement.BusinessLogic.Services;

namespace ChatSessionManagement.BusinessLogic.DependencyResolution
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
            services.AddScoped<IChatSessionAssignmentBackgroundServiceScope, ChatSessionAssignmentBackgroundServiceScope>();
            services.AddScoped<IChatSessionExpirationBackgroundServiceScope, ChatSessionExpirationBackgroundServiceScope>();

            return services;
        }
    }
}
