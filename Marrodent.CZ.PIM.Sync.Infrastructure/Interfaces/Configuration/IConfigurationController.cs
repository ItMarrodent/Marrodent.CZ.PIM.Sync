using Marrodent.CZ.PIM.Sync.Models.Enova.Configuration;

namespace Marrodent.CZ.PIM.Sync.Infrastructure.Interfaces.Configuration;

public interface IConfigurationController
{
    EnovaConfiguration GetEnovaConfiguration();
}