using ChatSessionManagement.Core.DTOs;

namespace ChatSessionManagement.DTOs
{
    public class CheckChatSessionStatusRequest : RequestBase
    {
        public string? Token { get; set; }
    }
}
