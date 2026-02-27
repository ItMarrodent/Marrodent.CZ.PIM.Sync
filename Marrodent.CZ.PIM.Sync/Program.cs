using Marrodent.CZ.PIM.Sync.Infrastructure.Controllers.Log;
using Marrodent.CZ.PIM.Sync.Infrastructure.Controllers.Rest;
using Marrodent.CZ.PIM.Sync.Infrastructure.Interfaces.Rest;
using Marrodent.CZ.PIM.Sync.Models.PIM.Configuration;
using Marrodent.CZ.PIM.Sync.Models.PIM.Responses;

ITokenController controller = new TokenController(new LogController("PIM"), new PimCredentials
{
    Username = "enova_7186",
    Password = "6901b9769",
    ClientId = "1_pymdu4p44uo8s48owc8gc8c0000g08ocg0ww8s0ggsgg0k8kg",
    ClientSecret = "3ncx22sdpeck40c80c0ok4kow0cc0g04kcggc8cgocggw4ks4k",
    AuthUrl = "https://pim-hs.ageno.work/api/oauth/v1/token"
});

TokenResponse response = await controller.GetToken();


