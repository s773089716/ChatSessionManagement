using ChatSessionManagement.BusinessLogic.Core.BackgroundServiceScopes;

namespace ChatSessionManagement.BusinessLogic.BackgroundServices
{
    public class ChatSessionAssignmentBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ChatSessionAssignmentBackgroundService> _logger;

        public ChatSessionAssignmentBackgroundService(IServiceProvider serviceProvider, ILogger<ChatSessionAssignmentBackgroundService> logger)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"{nameof(ChatSessionAssignmentBackgroundService)} is running.");

            await DoWorkAsync(stoppingToken);
        }

        private async Task DoWorkAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"{nameof(ChatSessionAssignmentBackgroundService)} is working.");

            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                IChatSessionAssignmentBackgroundServiceScope backgroundServiceScope = scope.ServiceProvider.GetRequiredService<IChatSessionAssignmentBackgroundServiceScope>();

                await backgroundServiceScope.AssignChatSessionToAgentAsync(stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"{nameof(ChatSessionAssignmentBackgroundService)} is stopping.");

            await base.StopAsync(stoppingToken);
        }
    }
}
