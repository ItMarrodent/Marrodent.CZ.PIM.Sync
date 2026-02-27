using Dapper;
using Marrodent.CZ.PIM.Sync.Infrastructure.Controllers.Data;
using Marrodent.CZ.PIM.Sync.Infrastructure.Controllers.Log;
using Marrodent.CZ.PIM.Sync.Infrastructure.Controllers.Rest;
using Marrodent.CZ.PIM.Sync.Infrastructure.Controllers.Sql;
using Marrodent.CZ.PIM.Sync.Infrastructure.Handlers;
using Marrodent.CZ.PIM.Sync.Infrastructure.Interfaces.Data;
using Marrodent.CZ.PIM.Sync.Infrastructure.Interfaces.Log;
using Marrodent.CZ.PIM.Sync.Infrastructure.Interfaces.Rest;
using Marrodent.CZ.PIM.Sync.Models.Data;
using Marrodent.CZ.PIM.Sync.Models.PIM.Configuration;

//Address
string address = @"https://pim-hs.ageno.work/api/rest/v1/categories/import/hs";

//SQL
string connectionString = @"Server=VPLCZDQAMSSQL01\ENOVA_DEV;Database=Enova_2306.1.5.0;User Id=devDBadmERP;Password=Zu6rkp5hnKCG_djtmrq_;TrustServerCertificate=True;MultipleActiveResultSets=True";
SqlMapper.AddTypeHandler(new SemicolonSeparatedIntListHandler());

//Log
ILogController logController = new LogController("PIM");

//Credentials
PimCredentials credentials = new PimCredentials
{
    Username = "enova_7186",
    Password = "6901b9769",
    ClientId = "1_pymdu4p44uo8s48owc8gc8c0000g08ocg0ww8s0ggsgg0k8kg",
    ClientSecret = "3ncx22sdpeck40c80c0ok4kow0cc0g04kcggc8cgocggw4ks4k",
    AuthUrl = "https://pim-hs.ageno.work/api/oauth/v1/token"
};

//Rest
ITokenController tokenController = new TokenController(logController, credentials);
ISendingController<ProductCategory> sendingController = new SendingController<ProductCategory>(tokenController, logController);

//Data
IProductsCategoriesDataController controller = new ProductsCategoriesDataController(new SqlController<ProductCategory>(connectionString));
var data = await controller.GetCategories();

//Send
await sendingController.Execute(HttpMethod.Post, new Uri(address), data);

//Stop
bool x = true;

