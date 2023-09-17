using ChatSessionManagement.Core.Repositories;
using ChatSessionManagement.Infrastructure.Factories;
using ChatSessionManagement.Infrastructure.Enumerations;
using ChatSessionManagement.Models;

namespace ChatSessionManagement.Repositories.InMemoryRepositories
{
    public class AgentRepository : IAgentRepository
    {                
        public Agent GetNextAgentBySeniorityType(SeniorityTypeEnum seniorityType)
        {        
            return AgentFactory.CreateAgent(seniorityType);
        }       
    }
}
