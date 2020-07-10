namespace P03.Mankind
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {          
            try
            {
                string[] studentArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string studentFirstName = studentArgs[0];
                string studentLastName = studentArgs[1];
                string facultyNumber = studentArgs[2];

                Student student = new Student(studentFirstName, studentLastName, facultyNumber);

                string[] workerArgs = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);

                string workerFirstName = workerArgs[0];
                string workerLastName = workerArgs[1];
                double weekSalary = double.Parse(workerArgs[1]);
                double workHoursPerDay = double.Parse(workerArgs[2]);

                Worker worker = new Worker(workerFirstName, workerLastName, weekSalary, workHoursPerDay);

                Console.WriteLine(student);
                Console.WriteLine();
                Console.WriteLine(worker);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
