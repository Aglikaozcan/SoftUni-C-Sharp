namespace P05_GreedyTimes2
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            long capacity = long.Parse(Console.ReadLine());

            Bag bag = new Bag(capacity);

            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i+=2)
            {
                string item = input[i];
                long quantity = long.Parse(input[i + 1]);

                if (item.Length == 3)
                {
                    bag.AddCash(item, quantity);
                }
                else if (item.ToLower().EndsWith("gem") && item.Length > 3)
                {
                    bag.AddGems(item, quantity);
                }
                else if (item.ToLower() == "gold")
                {
                    bag.AddGold(quantity);
                }
            }

            Console.WriteLine(bag.ToString());
        }
    }
}
