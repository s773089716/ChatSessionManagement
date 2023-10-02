using ChatSessionManagement.BusinessLogic.Infrastructure.Enumerations;

namespace ChatSessionManagement.BusinessLogic.Models
{
    public class MidLevelAgent : Agent
    {
        public MidLevelAgent()
        {
            SeniorityType = SeniorityTypeEnum.Midlevel;
        }
    }
}
