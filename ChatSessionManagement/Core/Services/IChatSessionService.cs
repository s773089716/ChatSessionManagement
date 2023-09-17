using ChatSessionManagement.Models;

namespace ChatSessionManagement.Core.Services
{
    public interface IChatSessionService
    {
        Task<ChatSession> CreateChatSession();

        Task<ChatSession> CheckChatSession(string token);
    }
}
