using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Marrodent.CZ.PIM.Sync.Infrastructure.Interfaces.Log;
using Marrodent.CZ.PIM.Sync.Infrastructure.Interfaces.Rest;
using Microsoft.Extensions.Logging;

namespace Marrodent.CZ.PIM.Sync.Infrastructure.Controllers.Rest
{
    public sealed class SendingController <T> : ISendingController<T>
    {
        //Private
        private readonly HttpClient _client;
        private readonly ITokenController _tokenController;
        private readonly ILogController _logController;

        //CTOR
        public SendingController(ITokenController tokenController, ILogController logController)
        {
            _client = new HttpClient();
            _tokenController = tokenController;
            _logController = logController;
        }

        //Public
        public async Task Execute(HttpMethod method, Uri address, ICollection<T> payload)
        {
            //Prepare - request
            HttpRequestMessage request = new HttpRequestMessage(method, address)
            {
                Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json")
            };

            //Add - auth header
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", (await _tokenController.GetToken()).AccessToken);

            //Execute
            HttpResponseMessage response = await _client.SendAsync(request);
            string json = await response.Content.ReadAsStringAsync();

            //Check - request
            if (!response.IsSuccessStatusCode)
            {
                _logController.Log(LogLevel.Error, json);
                throw new Exception($"Problem with token generating: {json}");
            }
        }
    }
}
