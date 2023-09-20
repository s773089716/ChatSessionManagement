using ChatSessionManagement.Core.BackgroundServiceScopes;

namespace ChatSessionManagement.BackgroundServices
{
    public class ChatSessionExpirationBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ChatSessionAssignmentBackgroundService> _logger;

        public ChatSessionExpirationBackgroundService(IServiceProvider serviceProvider, ILogger<ChatSessionAssignmentBackgroundService> logger)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"{nameof(ChatSessionExpirationBackgroundService)} is running.");

            await DoWorkAsync(stoppingToken);
        }

        private async Task DoWorkAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"{nameof(ChatSessionExpirationBackgroundService)} is working.");

            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                IChatSessionExpirationBackgroundServiceScope backgroundServiceScope = scope.ServiceProvider.GetRequiredService<IChatSessionExpirationBackgroundServiceScope>();

                await backgroundServiceScope.InactivateExpiredChatSessionsAsync(stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"{nameof(ChatSessionExpirationBackgroundService)} is stopping.");

            await base.StopAsync(stoppingToken);
        }
    }
}
