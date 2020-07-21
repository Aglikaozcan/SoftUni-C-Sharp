using System;
using System.Collections.Generic;

namespace _04._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            var continents = new Dictionary<string, List<string>>(); // continents - countries
            var countries = new Dictionary<string, List<string>>(); // countries - cities

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (continents.ContainsKey(continent) == false)
                {
                    continents[continent] = new List<string>();
                }

                if (!continents[continent].Contains(country))
                {
                    continents[continent].Add(country);
                }

                if (!countries.ContainsKey(country))
                {
                    countries[country] = new List<string>();
                }

                if (!countries[country].Contains(city))
                {
                    countries[country].Add(city);
                }
            }

            foreach (var continentKvp in continents)
            {
                var continent = continentKvp.Key;
                var countriesInContinent = continentKvp.Value;

                Console.WriteLine($"{continent}:");

                foreach (var country in countriesInContinent)
                {
                    var cities = countries[country];

                    Console.WriteLine($"  {country} -> {string.Join(", ", cities)}");
                }
            }
        }
    }
}
