using ChatSessionManagement.Infrastructure.Enumerations;

namespace ChatSessionManagement.Models
{
    public class LeadAgent : Agent
    {
        public LeadAgent()
        {
            SeniorityType = SeniorityTypeEnum.Lead;
        }
    }
}
