using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            string oper = Console.ReadLine();

            double result = 0.00;
            string output = string.Empty;

            if (n2 == 0 && (oper == "/" || oper == "%"))
            {
                output = string.Format($"Cannot divide {n1} by zero");
            }
            else if (oper == "/")
            {
                result = n1 / n2;
                output = string.Format($"{n1} {oper} {n2} = {result:f2}");
            }
            else if (oper == "%")
            {
                result = n1 % n2;
                output = string.Format($"{n1} {oper} {n2} = {result}");
            }
            else
            {
                if (oper == "+")
                {
                    result = n1 + n2;
                }
                else if (oper == "-")
                {
                    result = n1 - n2;
                }
                else if (oper == "*")
                {
                    result = n1 * n2;
                }
                if (result % 2 == 0)
                {
                    output = string.Format($"{n1} {oper} {n2} = {result} - even");

                }
                else
                {
                    output = string.Format($"{n1} {oper} {n2} = {result} - odd");

                }
            }
            Console.WriteLine(output);
        }
    }
}

