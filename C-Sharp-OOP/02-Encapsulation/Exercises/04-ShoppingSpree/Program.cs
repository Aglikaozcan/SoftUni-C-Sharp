namespace P04.ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Person> buyers = new List<Person>();
                List<Product> products = new List<Product>();

                string[] personInput = Console.ReadLine()
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < personInput.Length; i++)
                {
                    string[] personArgs = personInput[i]
                        .Split('=', StringSplitOptions.RemoveEmptyEntries);

                    string name = personArgs[0];
                    decimal money = decimal.Parse(personArgs[1]);

                    Person person = new Person(name, money);
                    buyers.Add(person);
                }

                string[] productInput = Console.ReadLine()
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < productInput.Length; i++)
                {
                    string[] productArgs = productInput[i]
                        .Split('=', StringSplitOptions.RemoveEmptyEntries);                                     

                    string productName = productArgs[0];
                    decimal cost = decimal.Parse(productArgs[1]);

                    Product product = new Product(productName, cost);
                    products.Add(product);
                }

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] commandArgs = command
                        .Split();

                    string personName = commandArgs[0];
                    string productName = commandArgs[1];

                    var person = buyers.FirstOrDefault(p => p.Name == personName);
                    var product = products.FirstOrDefault(p => p.ProductName == productName);

                    Console.WriteLine(person.BuyProduct(product));

                    command = Console.ReadLine();
                }

                foreach (var person in buyers)
                {
                    if (!person.BagWithProducts.Any())
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} - {string.Join(", ", person.BagWithProducts.Select(p => p.ProductName))}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
