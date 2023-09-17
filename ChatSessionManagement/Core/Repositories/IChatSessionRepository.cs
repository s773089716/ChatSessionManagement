using ChatSessionManagement.Models;

namespace ChatSessionManagement.Core.Repositories
{
    public interface IChatSessionRepository
    {
        Task<ChatSession> CreateNewChatSession();

        Task<ChatSession> CheckChatSessionStatus(string token);        
    }
}
