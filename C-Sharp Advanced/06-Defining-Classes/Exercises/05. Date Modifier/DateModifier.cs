using System;
using System.Collections.Generic;
using System.Text;

namespace _05._Date_Modifier
{
    public class DateModifier
    {
        public double FindDifference(string firstDate, string secondDate)
        {
            DateTime dateOne = DateTime.Parse(firstDate);
            DateTime dateTwo = DateTime.Parse(secondDate);

            return Math.Abs((dateOne - dateTwo).TotalDays);
        }
    }
}
