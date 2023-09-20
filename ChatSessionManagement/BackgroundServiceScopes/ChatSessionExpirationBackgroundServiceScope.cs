﻿using ChatSessionManagement.Core.BackgroundServiceScopes;
using ChatSessionManagement.Core.Services;
using ChatSessionManagement.Services;
using System.Text;

namespace ChatSessionManagement.BackgroundServiceScopes
{
    public class ChatSessionExpirationBackgroundServiceScope : IChatSessionExpirationBackgroundServiceScope
    {
        private readonly ILogger<ChatSessionExpirationBackgroundServiceScope> _logger;
        private IChatSessionService _chatSessionService;

        public ChatSessionExpirationBackgroundServiceScope(IChatSessionService chatSessionService, ILogger<ChatSessionExpirationBackgroundServiceScope> logger)
        {
            _logger = logger;
            _chatSessionService = chatSessionService;
        }

        public async Task InactivateExpiredChatSessionsAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                StringBuilder output = new StringBuilder("checking status");
                
                await _chatSessionService.InactivateExpiredChatSessions(stoppingToken);

                _logger.LogInformation($"{output.ToString()}\r\n");

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
