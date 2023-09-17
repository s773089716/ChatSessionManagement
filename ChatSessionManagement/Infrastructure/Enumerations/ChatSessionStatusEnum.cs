using System.Diagnostics.Tracing;

namespace ChatSessionManagement.Infrastructure.Enumerations
{
    public enum ChatSessionStatusEnum
    {
        None    = 0,
        Created = 10,
        Queued  = 20,
        Assigned= 30,
        Closed  = 40
    }
}
