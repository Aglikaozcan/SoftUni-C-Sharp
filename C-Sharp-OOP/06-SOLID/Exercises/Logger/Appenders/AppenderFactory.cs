using Logger.Appenders.Contracts;
using Logger.Layouts.Contracts;
using Logger.Loggers;
namespace Logger.Appenders
{
    using System;

    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            string typeAsLower = type.ToLower();

            switch (typeAsLower)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);
                case "fileappender":
                    return new FileAppender(layout, new LogFile());
                default:
                    throw new ArgumentException("Invalid appender Type!");
            }
        }
    }
}
