using ChatSessionManagement.Infrastructure.Enumerations;

namespace ChatSessionManagement.Models
{
    public class SeniorAgent : Agent
    {
        public SeniorAgent()
        {
            SeniorityType = SeniorityTypeEnum.Senior;
        }
    }
}
