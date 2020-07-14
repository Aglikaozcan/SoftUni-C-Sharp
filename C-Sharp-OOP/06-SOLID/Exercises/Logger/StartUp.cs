namespace Logger
{
    using Logger.Appenders;
    using Logger.Appenders.Contracts;
    using Logger.Layouts;
    using Logger.Layouts.Contracts;
    using Logger.Loggers.Contracts;
    using Logger.Loggers;
    using System;
    using Logger.Loggers.Enums;
    using Logger.Core;
    using Logger.Core.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            Engine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
