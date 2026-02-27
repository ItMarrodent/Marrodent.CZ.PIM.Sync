using Marrodent.CZ.PIM.Sync.Infrastructure.Interfaces.Configuration;
using Marrodent.CZ.PIM.Sync.Models.Enova.Configuration;
using System.Reflection;
using System.Text.Json;

namespace Marrodent.CZ.PIM.Sync.Infrastructure.Controllers.Configuration
{
    public sealed class ConfigurationController : IConfigurationController
    {
        //Private
        private static readonly string Path = $@"{System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\Configuration";

        //Public
        public EnovaConfiguration GetEnovaConfiguration()
        {
            return JsonSerializer.Deserialize<EnovaConfiguration>(File.ReadAllText($@"{Path}\enova.json"))!;
        }
    }
}
