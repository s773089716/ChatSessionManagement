using ChatSessionManagement.BusinessLogic.Models;
using ChatSessionManagement.BusinessLogic.Infrastructure.Factories;
using ChatSessionManagement.BusinessLogic.Core.Repositories;

namespace ChatSessionManagement.BusinessLogic.Repositories.InMemoryRepositories
{
    public class ChatSessionRepository : IChatSessionRepository
    {
        public async Task<ChatSession> CreateNewChatSession()
        {
            return await ChatSessionFactory.CreateNewChatSession();
        }

        public async Task<ChatSession> CheckChatSessionStatus(string token)
        {
            return await ChatSessionFactory.CreateNewChatSession();
        }
    }
}
