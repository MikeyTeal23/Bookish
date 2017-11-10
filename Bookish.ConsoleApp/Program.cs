using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Bookish.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Bookish"].ConnectionString);

            string SqlString = "SELECT TOP 100 [book_id],[title],[author],[isbn],[available] FROM [books]";
            var ourBooks = (List<Book>)db.Query<Book>(SqlString);

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
