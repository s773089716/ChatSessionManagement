using ChatSessionManagement.Core.BackgroundServiceScopes;
using ChatSessionManagement.Core.Services;
using System.Text;

namespace ChatSessionManagement.BackgroundServiceScopes
{
    public class ChatSessionAssignmentBackgroundServiceScope: IChatSessionAssignmentBackgroundServiceScope
    {
        private readonly ILogger<ChatSessionExpirationBackgroundServiceScope> _logger;
        private IChatSessionService _chatSessionService;

        public ChatSessionAssignmentBackgroundServiceScope(IChatSessionService chatSessionService, ILogger<ChatSessionExpirationBackgroundServiceScope> logger)
        {
            _logger = logger;
            _chatSessionService = chatSessionService;
        }

        public async Task AssignChatSessionToAgentAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                StringBuilder output = new StringBuilder("checking status");

                await _chatSessionService.AssignChatSessionToAgent(stoppingToken);

                _logger.LogInformation($"{output.ToString()}\r\n");

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
