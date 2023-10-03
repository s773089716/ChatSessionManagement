using ChatSessionManagement.BusinessLogic.Core.BackgroundServiceScopes;
using ChatSessionManagement.BusinessLogic.Core.Services;
using Microsoft.Extensions.Logging;
using System.Text;

namespace ChatSessionManagement.BusinessLogic.BackgroundServiceScopes
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
                StringBuilder output = new StringBuilder("assign session");

                await _chatSessionService.AssignChatSessionToAgent(stoppingToken);

                _logger.LogInformation($"{output.ToString()}\r\n");

                await Task.Delay(1000, stoppingToken);                
            }
        }
    }
}
