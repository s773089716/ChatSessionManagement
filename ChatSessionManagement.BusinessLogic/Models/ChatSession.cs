using ChatSessionManagement.BusinessLogic.Infrastructure.Enumerations;

namespace ChatSessionManagement.BusinessLogic.Models
{
    public class ChatSession
    {
        public string? Token { get; set; } = Guid.NewGuid().ToString();

        public ChatSessionStatusEnum Status { get; set; } = ChatSessionStatusEnum.None;

        public Agent? AssignedAgent { get; set; }

        public DateTime CreatedDateTime { get; } = DateTime.Now;

        public DateTime LastPollDateTime { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

    }
}
