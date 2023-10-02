using ChatSessionManagement.BusinessLogic.Core.DTOs;
using ChatSessionManagement.BusinessLogic.Models;

namespace ChatSessionManagement.BusinessLogic.DTOs
{
    public class CreateChatSessionResponse: ResponseBase
    {
        public ChatSession? ChatSession { get; set; }
    }
}
