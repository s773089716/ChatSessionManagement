using ChatSessionManagement.Infrastructure.Configurations;
using ChatSessionManagement.Infrastructure.Enumerations;

namespace ChatSessionManagement.Models
{
    public abstract class Agent
    {
        public string Id { get; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public SeniorityTypeEnum SeniorityType { get; set; } = SeniorityTypeEnum.Junior;        
        public float SeniorityMultiplier { get; set; }
        public byte Capacity { get; set; } = ApplicationConfig.ConcurrentChatsPerAgent;

        public Agent()
        {
            SeniorityMultiplier = SeniorityMultiplierConfig.GetSeniorityMultiplierBySeniorityTypeEnum(SeniorityType);
            Capacity = (byte)(ApplicationConfig.ConcurrentChatsPerAgent * SeniorityMultiplier);
        }
    }
}
