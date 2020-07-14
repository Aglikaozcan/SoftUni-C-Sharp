using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace basics
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(typeof(Program).Name); //дава името на програмата

            var catType = typeof(Cat); //тук знаем, че работим точно с котки

            var cat = new Cat(); //ако направим нова инстанция на класа, можем да вземем пълната информация за този клас така

            var catTypeFromInstance = cat.GetType();

            var catTypeFromName = Type.GetType("basics.Cat"); //всички тези правят едно и също

            Console.WriteLine(catType.BaseType.FullName); //дава името на базовия клас

            var interfaces = catType.GetInterfaces(); //спъсик на всички интерфейси, свързани с този клас

            foreach (var catInterface in interfaces)
            {
                Console.WriteLine(catInterface.FullName);
            }

            string animal = Console.ReadLine();
            string animalName = Console.ReadLine();

            Type animalType;

            if (animal == "Cat")
            {
                animalType = typeof(Cat);
            }
            else if (animal == "Dog")
            {
                animalType = typeof(Dog);
            }
            else
            {
                Console.WriteLine("Sorry!");
                return;
            }

            var catActivator = Activator.CreateInstance<Cat>(); //ако знаем какво животно искаме
            catActivator.Name = "Ivan";
            Console.WriteLine(catActivator.Name);

            //  ако имаме много животни и искаме да инстанцираме само едно от тях
            var newAnimalType = Type.GetType($"basics.{animal}"); //взимаме съответния клас
            if (newAnimalType == null) //ако такова животно или клас не съществува
            {
                Console.WriteLine("Animal not supported.");
                return;
            }
            var animalInstance = (Animal)Activator.CreateInstance(newAnimalType, new[] { animalName }); //трябва да се кастне към анимал, иначе го взима като обджект
            animalInstance.Name = animalName;
            Console.WriteLine($"{newAnimalType.Name} name: " + animalName);

            //ако искаме да извадим полетата
            var fields = typeof(Animal).GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in fields)
            {
                Console.WriteLine(field.IsPrivate);
            }

            //Ако искаме да извадим параметрите в конструктора
            string animalType2 = Console.ReadLine(); //прочитаме животното

            var newType = Type.GetType($"{typeof(Program).Namespace}.{animalType2}"); //намираме му съответния клас

            if (newType == null)
            {
                Console.WriteLine("Sorry!");
                return;
            }

            var constructor = newType.GetConstructors().First(); //взимаме първия конструктор, може да има няколко

            var parametersInfo = constructor.GetParameters(); //дава инфо за параметрите

            var parameterValues = new List<object>(); //списък за параметрите от конструктора

            foreach (var parameter in parametersInfo)
            {
                Console.Write($"Enter {parameter.Name}: "); //дава името на параметрите
                var parameterValue = Console.ReadLine();

                parameterValues.Add(parameterValue);
            }

            var animalInstance = (Animal)Activator
                .CreateInstance(newType, parameterValues.ToArray()); //създава ново животно с подадения конструктор

            Console.WriteLine(animalInstance.Name); //ще даде името на животното - Иван
        }

        public static void GetTypeName(object obj)
        {
            Console.WriteLine(obj.GetType().Name); //ако не знаем, какъв ни е обекта, използваме това записване
        }
    }
}
