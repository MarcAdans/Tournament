using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Tournament.Test
{
    public static class LoggerHelper
    {
        public static ILogger<T> GetLogger<T>()
        {
            var logger = Substitute.For<ILogger<T>>();

            logger.LogTrace(Arg.Any<string>(), Arg.Any<object[]>());
            logger.LogInformation(Arg.Any<string>());
            logger.LogError(Arg.Any<string>());

            return logger;
        }
    }
}