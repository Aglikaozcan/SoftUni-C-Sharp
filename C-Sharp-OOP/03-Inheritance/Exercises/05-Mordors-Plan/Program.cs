namespace P05.MordorsPlan
{
    using P05.MordorsPlan.Foods;
    using P05.MordorsPlan.Moods;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            List<Food> foods = new List<Food>();
            FoodFactory foodFactory = new FoodFactory();

            string[] foodInput = Console.ReadLine()
                .Split();

            foreach (var food in foodInput)
            {
                Food foodToAdd = foodFactory.GetFood(food);

                foods.Add(foodToAdd);
            }

            int happinessFood = foods
                .Select(x => x == null ? -1 : x.Happiness)
                .Sum();

            Console.WriteLine(happinessFood);

            if (happinessFood < -5)
            {
                Console.WriteLine(nameof(Angry));
            }
            else if (happinessFood >= -5 && happinessFood <= 0)
            {
                Console.WriteLine(nameof(Sad));
            }
            else if (happinessFood > 0 && happinessFood <= 15)
            {
                Console.WriteLine(nameof(Happy));
            }
            else
            {
                Console.WriteLine(nameof(JavaScript));
            }
        }
    }
}
