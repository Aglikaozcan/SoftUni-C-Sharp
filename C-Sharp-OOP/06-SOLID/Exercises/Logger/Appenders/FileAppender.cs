namespace Logger.Appenders
{
    using Logger.Layouts.Contracts;
    using Logger.Loggers.Contracts;
    using Logger.Loggers.Enums;
    using System;
    using System.IO;

    public class FileAppender : Appender
    {
        private const string Path = @"..\..\..\log.txt";
        private ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile)
            : base(layout)
        {
            this.logFile = logFile;
        }
        
        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {     
            if (this.ReportLevel <= reportLevel)
            {
                string content = string.Format(this.Layout.Format, dateTime, reportLevel, message) + Environment.NewLine;

                File.AppendAllText(Path, content);
            }
        }
    }
}
