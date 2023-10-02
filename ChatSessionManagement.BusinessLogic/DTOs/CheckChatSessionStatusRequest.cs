using ChatSessionManagement.BusinessLogic.Core.DTOs;

namespace ChatSessionManagement.BusinessLogic.DTOs
{
    public class CheckChatSessionStatusRequest : RequestBase
    {
        public string? Token { get; set; }
    }
}
