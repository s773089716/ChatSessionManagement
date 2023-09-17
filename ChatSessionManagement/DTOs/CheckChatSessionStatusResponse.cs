using ChatSessionManagement.Core.DTOs;
using ChatSessionManagement.Models;

namespace ChatSessionManagement.DTOs
{
    public class CheckChatSessionStatusResponse : ResponseBase
    {
        public ChatSession? ChatSession { get; set; }
    }
}
