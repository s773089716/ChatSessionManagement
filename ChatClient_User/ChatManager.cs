using ChatSessionManagement.BusinessLogic.DTOs;
using ChatSessionManagement.BusinessLogic.Models;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ChatClient_User
{
    public class ChatManager
    {
        private readonly ILogger _logger;
        //private readonly IBusinessLayer _business;
        private IHttpClientFactory _httpFactory { get; set; }
        public ChatManager(ILogger<ChatManager> logger, /*IBusinessLayer business,*/ IHttpClientFactory httpFactory)
        {
            _logger = logger;
            //_business = business;
            _httpFactory = httpFactory;
        }

        public async Task<CreateChatSessionResponse?> SendCreateChatSessionRequest()
        {
            //_logger.LogInformation("Application {applicationEvent} at {dateTime}", "Started", DateTime.UtcNow);

            CreateChatSessionResponse? responseObject = null;
            //ChatSession chatSession = null;
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5010/api/chatsession/CreateChatSession");

            var client = _httpFactory.CreateClient();
            var response = await client.SendAsync(request);
            //_business.PerformBusiness();

            //_logger.LogInformation("Application {applicationEvent} at {dateTime}", "Ended", DateTime.UtcNow);

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                responseObject = JsonSerializer.Deserialize<CreateChatSessionResponse>(responseString, new JsonSerializerOptions{ PropertyNameCaseInsensitive = true });                
                if (responseObject == null)
                {
                    responseObject = new CreateChatSessionResponse();
                    responseObject.Message = "API returned invalid response";
                    return responseObject;
                }
            }
            else
            {
                responseObject = new CreateChatSessionResponse();
                //response.StatusCode = response.StatusCode;
                responseObject.Message = $"Returned {response.StatusCode}";
                return responseObject;
            }

            return responseObject;
        }
    }
}
