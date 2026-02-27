using System.Net.Http.Headers;
using Marrodent.CZ.PIM.Sync.Infrastructure.Extensions;
using Marrodent.CZ.PIM.Sync.Infrastructure.Interfaces.Log;
using Marrodent.CZ.PIM.Sync.Infrastructure.Interfaces.Rest;
using Marrodent.CZ.PIM.Sync.Models.PIM.Configuration;
using Marrodent.CZ.PIM.Sync.Models.PIM.Responses;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Marrodent.CZ.PIM.Sync.Infrastructure.Controllers.Rest
{
    public sealed class TokenController : ITokenController
    {
        //Private
        private readonly HttpClient _client;
        private readonly ILogController _logController;
        private readonly PimCredentials _credentials;

        //CTOR
        public TokenController(ILogController logController, PimCredentials credentials)
        {
            _logController = logController;
            _credentials = credentials;
            _client = new HttpClient();
        }

        //Public
        public async Task<TokenResponse> GetToken()
        {
            //Prepare - payload
            FormUrlEncodedContent content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "grant_type", "password" },
                { "username",   _credentials.Username },
                { "password",   _credentials.Password }
            });

            //Prepare - request
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, _credentials.AuthUrl) { Content = content };
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", $"{_credentials.ClientId}:{_credentials.ClientSecret}".ToBase64());

            //Execute - request
            HttpResponseMessage response = await _client.SendAsync(request);
            string json = await response.Content.ReadAsStringAsync();

            //Check - request
            if (!response.IsSuccessStatusCode)
            {
                _logController.Log(LogLevel.Error, json);
                throw new Exception($"Problem with token generating: {json}");
            }

            //Result
            return JsonSerializer.Deserialize<TokenResponse>(json)!;
        }
    }
}
