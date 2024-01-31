using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Internship1
{
    public class Books
    {

        public string Title { get; set;}
        public string Author { get; set; }
        public string ISBN  { get; set;}
        public int NumberOfCopies { get; set;}
        public string BorrowCopies { get; set; }
        public DateTime Date { get;set; }
        public string Person { get; set; }

        public DateTime ReturnDate { get; set; }

        

        public Books(string title,string author,string isbn,int numberOfCopy)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            NumberOfCopies = numberOfCopy;
        }

        public Books(DateTime date,DateTime returnDate,string person,string isbn,string bookname) 
        {
            Date = date;
            ReturnDate = returnDate;
            Person = person;
            ISBN = isbn;
            Title = bookname;
        }

        


    }
}
