using ChatSessionManagement.BusinessLogic.Models;

namespace ChatSessionManagement.BusinessLogic.Core.Services
{
    public interface IChatSessionService
    {
        Task<ChatSession> CreateChatSession();

        Task<ChatSession> CheckChatSessionStatus(string token);

        Task InactivateExpiredChatSessions(CancellationToken stoppingToken);

        Task AssignChatSessionToAgent(CancellationToken stoppingToken);

        Task<ChatSession?> CloseChatSession(string token);
    }
}
