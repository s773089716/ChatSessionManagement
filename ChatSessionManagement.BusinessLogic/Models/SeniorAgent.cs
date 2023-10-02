using ChatSessionManagement.BusinessLogic.Infrastructure.Enumerations;

namespace ChatSessionManagement.BusinessLogic.Models
{
    public class SeniorAgent : Agent
    {
        public SeniorAgent()
        {
            SeniorityType = SeniorityTypeEnum.Senior;
        }
    }
}
