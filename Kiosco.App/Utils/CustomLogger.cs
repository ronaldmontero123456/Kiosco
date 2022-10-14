using DPWorldDR.Shared.Contracts;

namespace Kiosco.App.Utils
{
    public class CustomLogger : ICustomLogger
    {
        private readonly ILogger<CustomLogger> _logger;
        public CustomLogger(ILogger<CustomLogger> logger)
        {
            _logger = logger;
        }

        public void Debug(object message)
        {
            _logger.LogDebug(message.ToString());
            Console.WriteLine(message); 
        }

        public void Error(object message)
        {
            _logger.LogError(message.ToString());
            Console.WriteLine(message);
        }

        public void Fatal(object message)
        {
            _logger.LogCritical(message.ToString());
            Console.WriteLine(message);
        }

        public void Info(object message)
        {
            _logger.LogInformation(message.ToString());
            Console.WriteLine(message);
        }

        public void Warn(object message)
        {
            _logger.LogWarning(message.ToString());
            Console.WriteLine(message);
        }
    }
}
