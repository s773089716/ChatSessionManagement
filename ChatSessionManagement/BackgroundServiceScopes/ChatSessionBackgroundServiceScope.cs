using ChatSessionManagement.Core.Services;
using System.Text;

namespace ChatSessionManagement.BackgroundServiceScopes
{
    public class ChatSessionBackgroundServiceScope
    {
        private readonly ILogger<ChatSessionBackgroundServiceScope> _logger;
        private IChatSessionService _chatSessionService;

        public ChatSessionBackgroundServiceScope(IChatSessionService chatSessionService, ILogger<ChatSessionBackgroundServiceScope> logger)
        {
            _logger = logger;
            _chatSessionService = chatSessionService;
        }

        public async Task CheckChatSessionStatusAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                StringBuilder output = new StringBuilder("checking status");
                //output.Append("\r\nCheck Drone Battery Levels");
                //output.Append("\r\n==========================");

                //DronesListResponse dronesListResponse = await _chatSessionService.GetDronesList(new DronesListRequest { });
                //foreach (Drone drone in dronesListResponse.Drones)
                //{
                //    output.Append($"\r\nDrone: {drone.SerialNumber} => Battery Level: {drone.BatteryCapacity}");
                //}

                _logger.LogInformation($"{output.ToString()}\r\n");

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
