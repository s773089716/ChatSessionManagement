using ChatSessionManagement.BusinessLogic.Infrastructure.Enumerations;
using ChatSessionManagement.BusinessLogic.Models;

namespace ChatSessionManagement.BusinessLogic.Core.Repositories
{
    public interface IAgentRepository : IRepositoryBase
    {
        Agent GetNextAgentBySeniorityType(SeniorityTypeEnum seniorityType);
    }
}
