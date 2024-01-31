using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Internship1
{
    internal class Library
    {
        public List<Books> informations = new List<Books>();
        public List<Books> borrows = new List<Books>();


        public string Choice()
        {
            
            bool control = true;
            string choice = "";
            while (control)
            {             
                Console.WriteLine("Please choose a process(1/2/3/4/5/6)\n1)Add A Book\n2)View Books\n3)Borrow A Book\n4)Return A Book\n5)Search A Book\n6)View Expired Books");
                choice = Console.ReadLine();                           
                if (!int.TryParse(choice, out _))
                {
                    Console.WriteLine("Please just use numbers");
                }
                else
                {          
                    control = false;                   
                }
                

            }
            return choice;

        }
        public void AddBooks()
        {
            int ISBNLENGTH = 10;
            Console.WriteLine("Please write this informations of book: ISBN/Title/Author/Copy Number");

            Console.WriteLine("Title:");
            string title = Console.ReadLine().ToLower();
            Console.WriteLine("Author:");
            string author = Console.ReadLine().ToLower();
            string ISBN = "";
            while (true)
            {
                Console.WriteLine("ISBN:");
                ISBN = Console.ReadLine();
                if (ISBN.Length != ISBNLENGTH)
                {
                    Console.WriteLine("Please enter 10 characters long");
                }
                else if (!int.TryParse(ISBN, out _))
                {
                    Console.WriteLine("Please just use numbers");
                }
                else { break; }
            }
            int copy;
            while (true)
            {
                Console.WriteLine("Number of copy:");
                copy = int.Parse(Console.ReadLine());               
                if (!int.TryParse(ISBN, out _))
                {
                    Console.WriteLine("Please just use numbers");
                }
                else { break; }
            }
            

            Books books = new Books(title, author, ISBN, copy);
            informations.Add(books);
            Console.WriteLine("book added successfully");

        }
        public void ViewBooks()
        {

            foreach (Books i in informations)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("Title: " + i.Title);
                Console.WriteLine("Author: " + i.Author);
                Console.WriteLine("ISBN: " + i.ISBN);
                Console.WriteLine("Copy Number: " + i.NumberOfCopies);
                Console.WriteLine("---------------------------");
            }



        }

        public void BorrowBooks()
        {
            string isbn = "";
            string bookName = "";
            int control = 0;
            while (true)
            {
                Console.WriteLine("Please Enter the ISBN of the book to be borrowed\nISBN:");
                isbn = Console.ReadLine();
                
                
                foreach (Books i in informations)
                {
                    if (i.ISBN == isbn)
                    {
                        i.NumberOfCopies -= 1;
                        bookName = i.Title;
                        control++;
                    }

                }
                if (control == 0)
                {
                    Console.WriteLine("ISBN not found");
                }
                else { break; };
                
            }
            control = 0;
            
            Console.WriteLine("the name of the person who will buy the book: ");
            string name = Console.ReadLine().ToLower();
            Console.WriteLine("Please enter the date(2022-01-28):");

            Console.WriteLine("Year(2024): ");
            string year = Console.ReadLine();
            Console.WriteLine("Month: ");
            string month = Console.ReadLine();
            Console.WriteLine("Day: ");
            string day = Console.ReadLine();

            DateTime date = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
            int newMonth = int.Parse(month) + 1;
            if (int.Parse(month) == 12)
            newMonth = 1;

            DateTime returnDate = new DateTime(int.Parse(year), newMonth, int.Parse(day));

            Books books = new Books(date, returnDate, name, isbn, bookName);
            borrows.Add(books);

            foreach (Books i in borrows)
            {
                    Console.WriteLine("----------");
                    Console.WriteLine("Person: " + i.Person);
                    Console.WriteLine("Borrowed Book: " + i.Title);
                    Console.WriteLine("Borrow Date: " + i.Date);
                    Console.WriteLine("Return Date: " + i.ReturnDate);
                    Console.WriteLine("----------");

            }


        }
        public void ReturnBooks()
        {
            Console.WriteLine("Please enter ISBN: ");
            string isbn = Console.ReadLine();
            for (int i = borrows.Count - 1; i >= 0; i--)
            {
                if (borrows[i].ISBN == isbn)
                {
                    borrows.RemoveAt(i);
                }
            }
            foreach (Books i in borrows)
            {
                Console.WriteLine("----------");
                Console.WriteLine("Person: " + i.Person);
                Console.WriteLine("Borrowed Book: " + i.Title);
                Console.WriteLine("Borrow Date: " + i.Date);
                Console.WriteLine("Last Return Date: " + i.ReturnDate);
                Console.WriteLine("When Return: " + DateTime.Now);
                Console.WriteLine("----------");
            }
            foreach (Books j in informations)
            {
                if (j.ISBN == isbn)
                {
                    j.NumberOfCopies += 1;
                }
            }
        }
        public void LookForBooks()
        {
            Console.WriteLine("Search A Book(by book's name or author's name)");
            string search = Console.ReadLine();
            string searchLower = search.ToLower();
            int control = 0;

            foreach (Books i in informations)
            {
                string titleUpper = i.Title.ToLower();
                string authorUpper = i.Author.ToLower();
                if (titleUpper == searchLower || authorUpper == searchLower)
                {
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("Title: " + i.Title);
                    Console.WriteLine("Author: " + i.Author);
                    Console.WriteLine("ISBN: " + i.ISBN);
                    Console.WriteLine("Copy Number: " + i.NumberOfCopies);
                    Console.WriteLine("---------------------------");
                    control++;
                }
                else if (titleUpper.Contains(searchLower) || authorUpper.Contains(searchLower))
                {
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("Title: " + i.Title);
                    Console.WriteLine("Author: " + i.Author);
                    Console.WriteLine("ISBN: " + i.ISBN);
                    Console.WriteLine("Copy Number: " + i.NumberOfCopies);
                    Console.WriteLine("---------------------------");
                    control++;
                }
            }
            if (control == 0)
            {
                Console.WriteLine("not found");
            }
            control = 0;

        }
        public void ViewExpiredBooks()
        {
            foreach (Books i in borrows)
            {
                if (i.ReturnDate.Month < DateTime.Now.Month || i.ReturnDate.Year < DateTime.Now.Year)
                {
                    Console.WriteLine("Return Date: " + i.ReturnDate);
                    Console.WriteLine("Name Of Book: " + i.Title);
                    Console.WriteLine("Person: " + i.Person);
                }
                else if (i.ReturnDate.Month == DateTime.Now.Month && i.ReturnDate.Day < DateTime.Now.Day)
                {
                    Console.WriteLine("Return Date: " + i.ReturnDate);
                    Console.WriteLine("Name Of Book: " + i.Title);
                    Console.WriteLine("Person: " + i.Person);
                }


            }
        }



    }
        


    
    
}
