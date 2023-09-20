using ChatSessionManagement.Infrastructure.Configurations;
using ChatSessionManagement.Infrastructure.Enumerations;
using System.Collections.Concurrent;

namespace ChatSessionManagement.Models
{
    public abstract class Agent
    {
        public string Id { get; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public SeniorityTypeEnum SeniorityType { get; set; } = SeniorityTypeEnum.Junior;        
        public float SeniorityMultiplier { get; set; }
        public byte Capacity { get; set; } = 0;
        public BlockingCollection<ChatSession> AssignedChatSessions = new BlockingCollection<ChatSession>();

        public Agent()
        {
            SeniorityMultiplier = SeniorityMultiplierConfig.GetSeniorityMultiplierBySeniorityTypeEnum(SeniorityType);
            Capacity = (byte)(ApplicationConfig.ConcurrentChatsPerAgent * SeniorityMultiplier);
        }
    }
}
