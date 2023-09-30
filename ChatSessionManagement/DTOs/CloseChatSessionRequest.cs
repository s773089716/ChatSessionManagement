using ChatSessionManagement.Core.DTOs;

namespace ChatSessionManagement.DTOs
{
    public class CloseChatSessionRequest : RequestBase
    {
        public string? Token { get; set; }
    }
}
