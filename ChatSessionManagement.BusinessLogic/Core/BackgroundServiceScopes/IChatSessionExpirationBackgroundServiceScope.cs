namespace ChatSessionManagement.BusinessLogic.Core.BackgroundServiceScopes
{
    public interface IChatSessionExpirationBackgroundServiceScope
    {
        Task InactivateExpiredChatSessionsAsync(CancellationToken stoppingToken);
    }
}
