using System.Text;

namespace ChatSessionManagement.BusinessLogic.Core.BackgroundServiceScopes
{
    public interface IChatSessionAssignmentBackgroundServiceScope
    {
        Task AssignChatSessionToAgentAsync(CancellationToken stoppingToken);
    }
}
