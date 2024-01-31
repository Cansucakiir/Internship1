using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Internship1
{
    internal class Program
    {
        
        
        static void Main(string[] args)
        {
                                
            Library library = new Library();
            Books books = new Books("animal farm", "george orwell", "1234567891", 23);
            Books books2 = new Books("the hunger games", "suzanne callins", "1234567892", 30);
            Books books3 = new Books("romeo and juliet", "william shakespeare", "1234567893", 27);
            library.informations.Add(books);
            library.informations.Add(books2);
            library.informations.Add(books3);
            

            bool control = true;
            while (control)
            {
                               
                string choice = library.Choice();

                if (choice == "1")
                {
                    Console.Clear();
                    library.AddBooks();
                    
                    
                }
                if (choice == "2")
                {
                    Console.Clear();
                    library.ViewBooks();
                    
                }

                if (choice == "3")
                {
                    Console.Clear();
                    library.BorrowBooks();
                }
                if (choice == "4")
                {
                    Console.Clear();
                    library.ReturnBooks();
                }
                if (choice == "5")
                {
                    Console.Clear();
                    library.LookForBooks();
                }
                if (choice == "6")
                {
                    Console.Clear();
                    library.ViewExpiredBooks();
                }

            }
            
        }
    }

}
