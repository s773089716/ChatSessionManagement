using ChatSessionManagement.Core.DTOs;
using ChatSessionManagement.Models;

namespace ChatSessionManagement.DTOs
{
    public class CreateChatSessionResponse: ResponseBase
    {
        public ChatSession? ChatSession { get; set; }
    }
}
