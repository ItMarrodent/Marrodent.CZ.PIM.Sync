namespace Marrodent.CZ.PIM.Sync.Models.PIM.Responses
{
    public sealed class TokenResponse
    {
        public string AccessToken { get; set; } = null!;
        public string TokenType { get; set; } = null!;
        public int ExpiresIn { get; set; }
        public string? RefreshToken { get; set; }
        public string? Scope { get; set; }
    }
}
