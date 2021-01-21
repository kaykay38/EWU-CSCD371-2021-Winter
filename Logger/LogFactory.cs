using System.IO;

namespace Logger
{
    public class LogFactory
    {
        private string? _filePath { get; set; }

        public BaseLogger? CreateLogger(string className)
        {
            if (_filePath!=null && File.Exists(_filePath))
            {
                return new FileLogger(_filePath) { className = className };
            }
            else
            {
                return null;
            }
        }

        public void ConfigureFileLogger(string filePath)
        {
            _filePath = filePath;
        }
    }
}