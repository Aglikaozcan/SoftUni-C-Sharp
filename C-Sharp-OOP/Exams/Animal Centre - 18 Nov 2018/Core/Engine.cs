using AnimalCentre.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
    public class Engine : IEngine
    {
        private AnimalCentre animalCentre;

        public Engine()
        {
            this.animalCentre = new AnimalCentre();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                try
                {
                    string[] inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string command = inputArgs[0];
                    string[] args = inputArgs.Skip(1).ToArray();

                    string result = ReadCommand(command, args);

                    Console.WriteLine(result);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("InvalidOperationException: " + ex.Message);
                    throw;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("ArgumentException: " + ex.Message);
                    throw;
                }

                input = Console.ReadLine();
            }

            string adoptedAnimals = this.animalCentre.AllAdoptedAnimals();
            Console.WriteLine(adoptedAnimals);
        }

        private string ReadCommand(string command, string[] args)
        {
            string result = string.Empty;
            string name = string.Empty;
            int procedureTime = 0;

            if (command == "RegisterAnimal ")
            {
                //{type} {name} {energy} {happiness} {procedureTime}
                string type = args[0];
                name = args[1];
                int energy = int.Parse(args[2]);
                int happiness = int.Parse(args[3]);
                procedureTime = int.Parse(args[4]);

                result = this.animalCentre.RegisterAnimal(type, name, energy, happiness, procedureTime);
            }
            else if (command == "Chip")
            {
                name = args[0];
                procedureTime = int.Parse(args[1]);

                result = this.animalCentre.Chip(name, procedureTime);
            }
            else if (command == "Vaccinate")
            {
                name = args[0];
                procedureTime = int.Parse(args[1]);

                result = this.animalCentre.Chip(name, procedureTime);
            }
            else if (command == "Fitness")
            {
                name = args[0];
                procedureTime = int.Parse(args[1]);

                result = this.animalCentre.Fitness(name, procedureTime);
            }
            else if (command == "Play")
            {
                name = args[0];
                procedureTime = int.Parse(args[1]);

                result = this.animalCentre.Play(name, procedureTime);
            }
            else if (command == "DentalCare")
            {
                name = args[0];
                procedureTime = int.Parse(args[1]);

                result = this.animalCentre.DentalCare(name, procedureTime);
            }
            else if (command == "NailTrim")
            {
                name = args[0];
                procedureTime = int.Parse(args[1]);

                result = this.animalCentre.NailTrim(name, procedureTime);
            }
            else if (command == "Adopt")
            {
                name = args[0];
                string owner = args[1];

                result = this.animalCentre.Adopt(name, owner);
            }
            else if (command == "History")
            {
                name = args[0];

                result = this.animalCentre.History(name);
            }

            return result;
        }
    }
}
