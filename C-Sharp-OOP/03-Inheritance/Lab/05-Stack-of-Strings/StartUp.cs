using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var stack = new StackOfStrings();

            stack.PushRange("1", "2", "3");
        }
    }
}
