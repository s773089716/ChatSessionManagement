using ChatSessionManagement.BusinessLogic.Core.Repositories;
using ChatSessionManagement.BusinessLogic.Infrastructure.Factories;
using ChatSessionManagement.BusinessLogic.Infrastructure.Enumerations;
using ChatSessionManagement.BusinessLogic.Models;

namespace ChatSessionManagement.BusinessLogic.Repositories.InMemoryRepositories
{
    public class AgentRepository : IAgentRepository
    {                
        public Agent GetNextAgentBySeniorityType(SeniorityTypeEnum seniorityType)
        {        
            return AgentFactory.CreateAgent(seniorityType);
        }       
    }
}
