using ChatSessionManagement.Models;

namespace ChatSessionManagement.Core.Repositories
{
    public interface ITeamRepository : IRepositoryBase
    {
        Dictionary<string, Team>? Teams { get; }

        string GetAvailableNormalTeamName();

        string GetAvailableOverflowTeamName();
    }
}
