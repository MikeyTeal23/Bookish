using System;

namespace Bookish.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BookFactory bookFactory = new BookFactory();
            var ourBooks = bookFactory.RetrieveBooksFromDb();

            foreach (var books in ourBooks)
            {
                Console.WriteLine(new string('*', 20));
                Console.WriteLine("\nBook ID: " + books.book_id);
                Console.WriteLine("Title: " + books.title);
                Console.WriteLine("Author: " + books.author);
                Console.WriteLine("Is available? " + books.available + "\n");
                Console.WriteLine(new string('*', 20));
            }

            Console.ReadLine();
        }
    }
}
