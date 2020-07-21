using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> usernames = new HashSet<string>();
            var userFollowers = new Dictionary<string, HashSet<string>>();
            var userFollowing = new Dictionary<string, HashSet<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Statistics")
                {
                    break;
                }

                string[] tokens = input.Split();

                if (tokens.Length == 4)
                {
                    string name = tokens[0];

                    if (usernames.Contains(name) == false)
                    {
                        usernames.Add(name);
                        userFollowers.Add(name, new HashSet<string>());
                        userFollowing.Add(name, new HashSet<string>());
                    }                    
                }
                else
                {
                    string heFollows = tokens[0];
                    string followed = tokens[2];

                    if (usernames.Contains(heFollows) && usernames.Contains(followed) && heFollows != followed)
                    {
                        userFollowers[followed].Add(heFollows);
                        userFollowing[heFollows].Add(followed);
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {usernames.Count} vloggers in its logs.");

            var topUser = userFollowers
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => userFollowing[x.Key].Count())
                .FirstOrDefault();

            Console.WriteLine($"1. {topUser.Key} : {topUser.Value.Count} followers, {userFollowing[topUser.Key].Count} following");

            foreach (var username in topUser.Value.OrderBy(x => x))
            {
                Console.WriteLine($"*  {username}");
            }

            int count = 2;

            foreach (var kvp in userFollowers
                .Where(x => x.Key != topUser.Key)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => userFollowing[x.Key].Count()))
            {
                Console.WriteLine($"{count}. {kvp.Key} : {kvp.Value.Count} followers, {userFollowing[kvp.Key].Count} following");

                count++;
            }
        }
    }
}
