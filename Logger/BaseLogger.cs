namespace Logger
{
    public abstract class BaseLogger
    {
        // nullable property
        public string? ClassName { get; set; }
        public abstract void Log(LogLevel logLevel, string message);

    }
}
