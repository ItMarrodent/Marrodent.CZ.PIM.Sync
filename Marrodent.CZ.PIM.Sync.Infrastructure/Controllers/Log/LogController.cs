using Microsoft.Extensions.Logging;
using System.Reflection;
using Marrodent.CZ.PIM.Sync.Infrastructure.Interfaces.Log;

namespace Marrodent.CZ.PIM.Sync.Infrastructure.Controllers.Log
{
    public sealed class LogController : ILogController
    {
        //Name
        private readonly ILogger _logger;
        private readonly ITextLogController _textLogController;

        //CTOR
        public LogController(string name)
        {
            _logger = LoggerFactory.Create(x => x.AddEventLog().AddConsole()).CreateLogger(name);
            _textLogController = new TextLogController($@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\Log");
        }

        //Public
        public void Log(LogLevel type, string message)
        {
            _logger.Log(type, message);
            _textLogController.Log(type, message);
        }

        public void Log(LogLevel type, Exception exception, string? message)
        {
            _logger.Log(type, exception, message);
            _textLogController.Log(type, exception);
        }
    }
}
