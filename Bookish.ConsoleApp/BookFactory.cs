using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace Bookish.ConsoleApp
{
    public class BookFactory
    {
        public Dictionary<Book, BookAvailabilityHelper> GetDictOfBooks()
        {
            List<Book> DBBooksList = RetrieveBooksFromDb();
            Dictionary<Book, BookAvailabilityHelper> bookDictionary = PopulateDictionary(DBBooksList);
            return bookDictionary;
        }

        public List<Book> RetrieveBooksFromDb()
        {
            IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Bookish"].ConnectionString);

            string SqlString = "SELECT TOP 100 [book_id],[title],[author],[isbn],[available] FROM [books]";
            var ourBooks = (List<Book>)db.Query<Book>(SqlString);
            return ourBooks;
        }

        public Dictionary<Book, BookAvailabilityHelper> PopulateDictionary(List<Book> DBBooksList)
        {
            Dictionary<Book, BookAvailabilityHelper> bookDictionary = new Dictionary<Book, BookAvailabilityHelper>();

            foreach (var book in DBBooksList)
            {
                var availabilityHelper = book.available 
                    ? new BookAvailabilityHelper(1,1) 
                    : new BookAvailabilityHelper(1,0);
                if (bookDictionary.All(t => t.Key.isbn != book.isbn))
                {
                    bookDictionary.Add(book, availabilityHelper);
                }
                else
                {
                    var matchingBookEntry = bookDictionary.FirstOrDefault(b => b.Key.isbn == book.isbn).Key;
                    bookDictionary[matchingBookEntry].NoOfBooks += availabilityHelper.NoOfBooks;
                    bookDictionary[matchingBookEntry].NoOfAvailableBooks += availabilityHelper.NoOfAvailableBooks;
                }
            }

            return bookDictionary;
        }

        public void AddBook(string title, string author, string isbn)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Bookish"].ConnectionString))
            {
                var query = "INSERT INTO dbo.books (title,author,isbn,available) VALUES (@title,@author,@isbn, 1)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@author", author);
                    command.Parameters.AddWithValue("@isbn", isbn);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                }
            }
        }
    }
}