using Microsoft.Extensions.Logging;

namespace Marrodent.CZ.PIM.Sync.Infrastructure.Interfaces.Log
{
    public interface ITextLogController
    {
        void Log(LogLevel type, string message);
        void Log(LogLevel type, Exception exception);
    }
}
