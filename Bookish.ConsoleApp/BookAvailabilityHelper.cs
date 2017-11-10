using System;

namespace Bookish.ConsoleApp
{
    public class BookAvailabilityHelper
    {
        public int NoOfAvailableBooks { get; set; }
        public int NoOfBooks { get; set; }

        public BookAvailabilityHelper(int noOfBooks, int noOfAvailableBooks)
        {
            NoOfBooks = noOfBooks;
            NoOfAvailableBooks = noOfAvailableBooks;
        }
    }
}