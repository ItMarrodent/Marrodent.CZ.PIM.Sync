using System.Text.Json.Serialization;

namespace Marrodent.CZ.PIM.Sync.Models.PIM.Responses
{
    public sealed class TokenResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; } = null!;

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; } = null!;

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonPropertyName("refresh_token")]
        public string? RefreshToken { get; set; }

        [JsonPropertyName("scope")]
        public string? Scope { get; set; }

        [JsonIgnore]
        public DateTime CreationTime { get; } = DateTime.Now; 
    }
}
