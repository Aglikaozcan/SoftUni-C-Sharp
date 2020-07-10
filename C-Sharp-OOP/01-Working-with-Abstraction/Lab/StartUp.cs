namespace P03_StudentSystem
{
    using P03_StudentSystem.Commands;
    using P03_StudentSystem.Students;

    public class StartUp
    {
        public static void Main()
        {
            var studentSystem = new StudentSystem();
            var commandParser = new CommandParser();
            var engine = new Engine(commandParser, studentSystem);

            engine.Run();
        }
    }
}
