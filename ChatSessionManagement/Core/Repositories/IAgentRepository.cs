using ChatSessionManagement.Infrastructure.Enumerations;
using ChatSessionManagement.Models;

namespace ChatSessionManagement.Core.Repositories
{
    public interface IAgentRepository : IRepositoryBase
    {
        Agent GetNextAgentBySeniorityType(SeniorityTypeEnum seniorityType);
    }
}
