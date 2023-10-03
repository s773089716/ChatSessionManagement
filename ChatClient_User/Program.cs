using ChatSessionManagement.BusinessLogic.DTOs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static System.Net.Mime.MediaTypeNames;

namespace ChatClient_User
{
   class Program
    {
        static async Task<int> Main(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHttpClient();
                    services.AddTransient<ChatManager>();
                }).UseConsoleLifetime();

            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                    var myService = services.GetRequiredService<ChatManager>();
                    CreateChatSessionResponse? createChatSessionResponse = await myService.SendCreateChatSessionRequest();

                    if (createChatSessionResponse != null && createChatSessionResponse.ChatSession != null && !String.IsNullOrEmpty(createChatSessionResponse.ChatSession.Token))
                    {
                        Console.WriteLine($"Token returned: {createChatSessionResponse.ChatSession.Token}");

                        for (int index = 0; index < 10; index++)
                        {
                            CheckChatSessionStatusResponse? checkChatSessionStatusResponse = await myService.CheckChatSessionStatusRequest(createChatSessionResponse.ChatSession.Token);

                            if (checkChatSessionStatusResponse != null && checkChatSessionStatusResponse.ChatSession != null && !String.IsNullOrEmpty(checkChatSessionStatusResponse.ChatSession.Token))
                            {
                                Console.WriteLine($"New status: {createChatSessionResponse.ChatSession.Status}");
                                await Task.Delay(1000);
                            }
                        }
                    }
                        
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error Occured {ex.Message}");
                }
            }

            return 0;
        }
    }
}