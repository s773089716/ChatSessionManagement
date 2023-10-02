using ChatSessionManagement.BusinessLogic.Infrastructure.Enumerations;

namespace ChatSessionManagement.BusinessLogic.Models
{
    public class JuniorAgent : Agent
    {
        public JuniorAgent() 
        {
            SeniorityType = SeniorityTypeEnum.Junior;
        }
    }
}
