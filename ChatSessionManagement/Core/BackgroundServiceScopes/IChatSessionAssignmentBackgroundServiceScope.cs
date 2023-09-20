using System.Text;

namespace ChatSessionManagement.Core.BackgroundServiceScopes
{
    public interface IChatSessionAssignmentBackgroundServiceScope
    {
        Task AssignChatSessionToAgentAsync(CancellationToken stoppingToken);
    }
}
