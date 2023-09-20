namespace ChatSessionManagement.Core.BackgroundServiceScopes
{
    public interface IChatSessionExpirationBackgroundServiceScope
    {
        Task InactivateExpiredChatSessionsAsync(CancellationToken stoppingToken);
    }
}
