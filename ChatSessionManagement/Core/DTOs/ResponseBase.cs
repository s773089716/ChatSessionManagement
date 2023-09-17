using ChatSessionManagement.Infrastructure.Enumerations;

namespace ChatSessionManagement.Core.DTOs
{
    public abstract class ResponseBase : IResponseBase
    {
        public string Message { get; set; } = String.Empty;
        public DTOMessageType MessageType { get; set; } = DTOMessageType.None;
    }
}
