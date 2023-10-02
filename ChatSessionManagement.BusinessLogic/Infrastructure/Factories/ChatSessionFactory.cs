using ChatSessionManagement.BusinessLogic.Infrastructure.Enumerations;
using ChatSessionManagement.BusinessLogic.Models;

namespace ChatSessionManagement.BusinessLogic.Infrastructure.Factories
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
