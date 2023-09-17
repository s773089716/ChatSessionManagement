using ChatSessionManagement.Infrastructure.Enumerations;
using ChatSessionManagement.Models;

namespace ChatSessionManagement.Infrastructure.Factories
{
    public static class ChatSessionFactory
    {
        public async static Task<ChatSession> CreateNewChatSession()
        {
            return new ChatSession()
            { 
                Status = ChatSessionStatusEnum.Created 
            };
        }
    }
}
