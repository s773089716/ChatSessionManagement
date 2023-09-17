using ChatSessionManagement.Infrastructure.Enumerations;
using ChatSessionManagement.Models;
using System.Reflection.Metadata.Ecma335;

namespace ChatSessionManagement.Infrastructure.Factories
{
    public static class AgentFactory
    {
        public static Agent CreateAgent(SeniorityTypeEnum seniorityType)
        {
            Agent agent;

            switch (seniorityType)
            {
                case SeniorityTypeEnum.Midlevel:
                    agent = new MidLevelAgent();
                    break;
                case SeniorityTypeEnum.Senior:
                    agent = new SeniorAgent();
                    break;
                case SeniorityTypeEnum.Lead:
                    agent = new LeadAgent();
                    break;
                default:
                    agent = new JuniorAgent();
                    break;
            }

            return agent;
        }
    }
}
