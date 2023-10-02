using ChatSessionManagement.BusinessLogic.Infrastructure.Enumerations;

namespace ChatSessionManagement.BusinessLogic.Models
{
    public class LeadAgent : Agent
    {
        public LeadAgent()
        {
            SeniorityType = SeniorityTypeEnum.Lead;
        }
    }
}
