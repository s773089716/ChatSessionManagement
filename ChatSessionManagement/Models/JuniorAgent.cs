using ChatSessionManagement.Infrastructure.Enumerations;

namespace ChatSessionManagement.Models
{
    public class JuniorAgent : Agent
    {
        public JuniorAgent() 
        {
            SeniorityType = SeniorityTypeEnum.Junior;
        }
    }
}
