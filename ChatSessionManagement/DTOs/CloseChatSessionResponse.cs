using ChatSessionManagement.Core.DTOs;
using ChatSessionManagement.Models;

namespace ChatSessionManagement.DTOs
{
    public class CloseChatSessionResponse : ResponseBase
    {
        public ChatSession? ChatSession { get; set; }
    }
}
