using System.Text.Json;
using Marrodent.CZ.PIM.Sync.Infrastructure.Extensions;
using Marrodent.CZ.PIM.Sync.Infrastructure.Interfaces.Log;
using Marrodent.CZ.PIM.Sync.Infrastructure.Interfaces.Rest;
using Marrodent.CZ.PIM.Sync.Models.PIM.Configuration;
using Marrodent.CZ.PIM.Sync.Models.PIM.Responses;
using Microsoft.Extensions.Logging;

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
            FormUrlEncodedContent content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["grant_type"] = "password",
                ["client_id"] = _credentials.ClientId.ToBase64(),
                ["client_secret"] = _credentials.ClientSecret.ToBase64(),
                ["username"] = _credentials.Username,
                ["password"] = _credentials.Password,
            });

            HttpResponseMessage response = await _client.PostAsync(new Uri(_credentials.AuthUrl), content);
            string json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                _logController.Log(LogLevel.Error, json);
            }

            return JsonSerializer.Deserialize<TokenResponse>(json)!;
        }
    }
}
