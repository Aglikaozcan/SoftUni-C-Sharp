namespace P02.BookShop
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string author = Console.ReadLine();
                string title = Console.ReadLine();
                decimal price = decimal.Parse(Console.ReadLine());

                Book book = new Book(author, title, price);
                GoldenEditionBook goldenEditionBook = new GoldenEditionBook(author, title, price);

                Console.WriteLine(book);
                Console.WriteLine();
                Console.WriteLine(goldenEditionBook);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
