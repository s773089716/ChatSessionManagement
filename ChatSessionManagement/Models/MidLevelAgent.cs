using ChatSessionManagement.Infrastructure.Enumerations;

namespace ChatSessionManagement.Models
{
    public class MidLevelAgent : Agent
    {
        public MidLevelAgent()
        {
            SeniorityType = SeniorityTypeEnum.Midlevel;
        }
    }
}
