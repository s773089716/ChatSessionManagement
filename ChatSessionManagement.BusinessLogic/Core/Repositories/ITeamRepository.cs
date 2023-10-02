using ChatSessionManagement.BusinessLogic.Models;
using System.Collections.Concurrent;

namespace ChatSessionManagement.BusinessLogic.Core.Repositories
{
    public interface ITeamRepository : IRepositoryBase
    {
        ConcurrentDictionary<string, Team>? Teams { get; }

        string GetAvailableNormalTeamName();

        string GetAvailableOverflowTeamName();

        string GetOverflowTeamName();
    }
}
