using System;
namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger? baseLogger, string message, params object[] messageArguments)
        {
            if (baseLogger == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                string fullMessage = string.Format(message, messageArguments);
                baseLogger.Log(LogLevel.Error, fullMessage);
            }
        }
        public static void Warning(this BaseLogger? baseLogger, string message, params object[] messageArguments)
        {
            if (baseLogger == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                string fullMessage = string.Format(message, messageArguments);
                baseLogger.Log(LogLevel.Warning, fullMessage);
            }
        }
        public static void Information(this BaseLogger? baseLogger, string message, params object[] messageArguments)
        {
            if (baseLogger == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                string fullMessage = string.Format(message, messageArguments);
                baseLogger.Log(LogLevel.Information, fullMessage);
            }
        }
        public static void Debug(this BaseLogger? baseLogger, string message, params object[] messageArguments)
        {
            if (baseLogger == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                string fullMessage = string.Format(message, messageArguments);
                baseLogger.Log(LogLevel.Debug, fullMessage);
            }
        }
    }
}