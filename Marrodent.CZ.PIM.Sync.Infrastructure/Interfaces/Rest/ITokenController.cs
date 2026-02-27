using Marrodent.CZ.PIM.Sync.Models.PIM.Responses;

namespace Marrodent.CZ.PIM.Sync.Infrastructure.Interfaces.Rest;

public interface ITokenController
{
    Task<TokenResponse> GetToken();
}