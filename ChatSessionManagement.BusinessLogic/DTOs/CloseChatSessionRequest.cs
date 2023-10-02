using ChatSessionManagement.BusinessLogic.Core.DTOs;

namespace ChatSessionManagement.BusinessLogic.DTOs
{
    public class CloseChatSessionRequest : RequestBase
    {
        public string? Token { get; set; }
    }
}
