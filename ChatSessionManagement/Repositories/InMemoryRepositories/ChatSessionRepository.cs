using ChatSessionManagement.Models;
using ChatSessionManagement.Infrastructure.Factories;
using ChatSessionManagement.Core.Repositories;

namespace ChatSessionManagement.Repositories.InMemoryRepositories
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
