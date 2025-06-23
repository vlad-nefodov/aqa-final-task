using Business.Abstractions;

namespace Core.Adapters
{
    public class LoggerAdapter : ILogger
    {
        private readonly NLog.ILogger _logger;

        public LoggerAdapter(NLog.ILogger logger)
        {
            _logger = logger;
        }

        public void Debug(string message) => _logger.Debug(message);

        public void Trace(string message) => _logger.Trace(message);

        public void Warn(string message) => _logger.Warn(message);

        public void Error(string message) => _logger.Error(message);
    }
}
