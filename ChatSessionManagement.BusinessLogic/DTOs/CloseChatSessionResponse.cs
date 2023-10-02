using ChatSessionManagement.BusinessLogic.Core.DTOs;
using ChatSessionManagement.BusinessLogic.Models;

namespace ChatSessionManagement.BusinessLogic.DTOs
{
    public class CloseChatSessionResponse : ResponseBase
    {
        public ChatSession? ChatSession { get; set; }
    }
}
