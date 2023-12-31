﻿namespace ChatSessionManagement.BusinessLogic.Infrastructure.Configurations
{
    public static class ApplicationConfig
    {
        public static readonly byte ConcurrentChatsPerAgent = 10;
        public static readonly float QueueMutiplier = 1.5F;
        public static readonly int ExpirationDurationInSeconds = 3000;
    }
}
