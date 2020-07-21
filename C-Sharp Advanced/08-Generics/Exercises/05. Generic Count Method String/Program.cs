using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.GenericCountMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());

            Box<string> box = new Box<string>();

            for (int i = 0; i < linesCount; i++)
            {
                string line = Console.ReadLine();
                box.Add(line);
            }
            
            string element = Console.ReadLine();

            int count = GetCountOfGreaterElements(box.Data, element);

            Console.WriteLine(count);
        }

        public static int GetCountOfGreaterElements<T>(List<T> listWithData, T element)
            where T : IComparable
        {
            int count = 0;

            foreach (var item in listWithData)
            {
                if (item.CompareTo(element) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        static void Swap<T>(List<T> listWithData, int firstIndex, int secondIndex)
        {
            T temp = listWithData[firstIndex];
            listWithData[firstIndex] = listWithData[secondIndex];
            listWithData[secondIndex] = temp;
        }
    }
}
