using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private string? _filePath { get; set; }
        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }
        public override void Log(LogLevel logLevel, string message)
        {
            if (!File.Exists(_filePath))
            {
                throw new FileNotFoundException();
            }
            else
            {
                StreamWriter writer = new StreamWriter(_filePath, true);
                string logMessage = $"{DateTime.Now:MM/dd/yyyy hh:mm:ss t} {nameof(className)} {logLevel}: {message}";
                writer.WriteLine(logMessage);
                writer.Close();
            }
        }
    }
}