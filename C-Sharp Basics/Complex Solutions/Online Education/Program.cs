using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Education
{
    class Program
    {
        static void Main(string[] args)
        {
            string formEarly = Console.ReadLine();
            int studentsEarly = int.Parse(Console.ReadLine());
            string formRegular = Console.ReadLine();
            int studentsRegular = int.Parse(Console.ReadLine());
            string formLate = Console.ReadLine();
            int studentsLate = int.Parse(Console.ReadLine());

            int totsalStud = studentsEarly + studentsRegular + studentsLate;
            bool isOnsite = formEarly == "onsite" || formRegular == "onsite" || formLate == "onsite";
            int studentsOnsite = 0;
            if (isOnsite)
            {

            }
            if (formEarly == "onsite")
            {
                studentsEarly = studentsOnsite;
            }

        }
    }
}
