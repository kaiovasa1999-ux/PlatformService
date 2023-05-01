using PlatformService.DTOs;
using System.Text;
using System.Text.Json;

namespace PlatformService.SyncDataServices.HttpClients
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task SendPlatformToCommandService(PlatfromReadDTO data)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(data),
                Encoding.UTF8,
                "application/json");
            //will put this URI to config
            var response = await _httpClient.PostAsync($"{_configuration["CommandServiceURL"]}", httpContent);
         
            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine("Everything was OK!");
            }
            else
            {
                Console.WriteLine("BAD!");
            }
        }
    }
}
