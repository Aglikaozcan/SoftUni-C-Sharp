using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Company_Roster
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int countOfEmployees = int.Parse(Console.ReadLine());

            var departments = new Dictionary<string, List<double>>(); //department name and salary
            var employees = new List<Employee>();

            for (int i = 0; i < countOfEmployees; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                //name, salary, position, department, email and age
                string name = input[0];
                double salary = double.Parse(input[1]);
                string position = input[2];
                string department = input[3];

                Employee employee = null;

                if (input.Length == 4)
                {
                    employee = new Employee(name, salary, position, department);
                }
                else if (input.Length == 6)
                {
                    string email = input[4];
                    int age = int.Parse(input[5]);

                    employee = new Employee(name, salary, position, department, email, age);
                }
                else
                {
                    bool isAge = int.TryParse(input[4], out int age);

                    if (isAge)
                    {
                        employee = new Employee(name, salary, position, department, age);
                    }
                    else
                    {
                        string email = input[4];
                        employee = new Employee(name, salary, position, department, email);
                    }
                }

                employees.Add(employee);

                if (departments.ContainsKey(department) == false)
                {
                    departments[department] = new List<double>();
                }
                departments[department].Add(salary);
            }

            var bestDepartment = departments
                .OrderByDescending(d => d.Value.Average())
                .First();

            var choosenDepartment = employees
                .Where(e => e.Department == bestDepartment.Key)
                .OrderByDescending(e => e.Salary)
                .ToList();

            Console.WriteLine($"Highest Average Salary: {choosenDepartment[0].Department}");

            foreach (var employee in choosenDepartment)
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
            }
        }
    }
}
