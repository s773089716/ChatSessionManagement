using Microsoft.Extensions.Logging;

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

        public async Task<string> Run()
        {
            _logger.LogInformation("Application {applicationEvent} at {dateTime}", "Started", DateTime.UtcNow);


            var request = new HttpRequestMessage(HttpMethod.Get, "https://TheCodeBuzz.com");

            var client = _httpFactory.CreateClient();
            var response = await client.SendAsync(request);
            //_business.PerformBusiness();

            _logger.LogInformation("Application {applicationEvent} at {dateTime}", "Ended", DateTime.UtcNow);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return $"StatusCode: {response.StatusCode}";
            }
        }
    }
}
