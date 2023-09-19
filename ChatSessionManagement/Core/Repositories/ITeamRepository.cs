using ChatSessionManagement.Models;
using System.Collections.Concurrent;

namespace ChatSessionManagement.Core.Repositories
{
    public interface ITeamRepository : IRepositoryBase
    {
        ConcurrentDictionary<string, Team>? Teams { get; }

        string GetAvailableNormalTeamName();

        string GetAvailableOverflowTeamName();
    }
}
