using ChatSessionManagement.Infrastructure.Enumerations;

namespace ChatSessionManagement.Models
{
    public abstract class Team
    {
        public string Id { get; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = String.Empty;
        public TeamTypeEnum TeamType { get; set; } = TeamTypeEnum.Normal;
        public List<Agent> MemberList { get; set; } = new List<Agent>();    
        
        public short Capacity
        {
            get
            {
                short capacity = 0;

                foreach (var agent in MemberList)                
                    capacity += agent.Capacity;

                return capacity;
            }
        }
    }
}
