using Marrodent.CZ.PIM.Sync.Infrastructure.Interfaces.Log;
using Microsoft.Extensions.Logging;

namespace Marrodent.CZ.PIM.Sync.Infrastructure.Controllers.Log
{
    public sealed class TextLogController(string path) : ITextLogController
    {
        //Private
        private string LogPath(LogLevel level) => $"{path}\\{level}";
        private string LogFile(LogLevel level) => $"{LogPath(level)}\\{DateTime.Today:yyyy_MM_dd}.txt";

        //Public
        public void Log(LogLevel type, string message)
        {
            CheckPath(type);
            File.AppendAllText(LogFile(type), $"\n{DateTime.Now:HH:mm:ss} - {message}");
        }

        public void Log(LogLevel type, Exception exception)
        {
            CheckPath(type);
            File.AppendAllText(LogFile(type), $"\n{DateTime.Now:HH:mm:ss} - {exception}");
        }

        //Private
        private void CheckPath(LogLevel level)
        {
            if (!Directory.Exists(LogPath(level)))
            {
                Directory.CreateDirectory(LogPath(level));
            }
        }
    }
}
