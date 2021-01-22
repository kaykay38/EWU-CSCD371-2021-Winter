using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private string? _filePath;
        public string? FilePath
        {
            get
            {
                return _filePath;
            }
            set => _filePath = value;
        }
        public FileLogger(string filePath)
        {
            FilePath = filePath ?? throw new ArgumentNullException();
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
                string logMessage = $"{DateTime.Now:MM/dd/yyyy hh:mm:ss tt} {base.ClassName} {logLevel}: {message}";
                writer.WriteLine(logMessage);
                writer.Close();
            }
        }
    }
}
