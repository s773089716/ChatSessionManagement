using ChatSessionManagement.Infrastructure.Enumerations;

namespace ChatSessionManagement.Models
{
    public class ChatSession
    {
        public string? Token { get; } = Guid.NewGuid().ToString();

        public ChatSessionStatusEnum Status { get; set; } = ChatSessionStatusEnum.None;

    }
}
