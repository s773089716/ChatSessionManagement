using ChatSessionManagement.BusinessLogic.Models;

namespace ChatSessionManagement.BusinessLogic.Core.Repositories
{
    public interface IChatSessionRepository
    {
        Task<ChatSession> CreateNewChatSession();

        Task<ChatSession> CheckChatSessionStatus(string token);        
    }
}
