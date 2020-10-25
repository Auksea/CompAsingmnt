using System;
using System.Collections.Generic;
using System.Text;

namespace TCPServer
{
    class Menu
    {
        public static void MainMenu()
        {
            Boolean status = true;

            while (status)
            {
                Console.WriteLine("Give your choice 1,2,3,9:");
                Console.WriteLine("1: Get all books");
                Console.WriteLine("2: Get a book by Isbn number");
                Console.WriteLine("3: Add a new book");

                Console.WriteLine("9: Exit program");

                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine("Key:" + key);

                if (char.IsDigit(key.KeyChar))
                {
                    int choice = Convert.ToInt32(key.KeyChar) - 48;

                    Console.WriteLine("choice:" + choice);
                    switch (choice)
                    {
                        case 1:
                            menu1(); break;
                        case 2:
                            menu2(); break;
                        case 3:
                            menu3(); break;
                        default:
                            Console.WriteLine("Sorry wrong number not (1,2,3,4,9) ");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nSorry, you need to input a number");
                }
            }
        }

        private static void menu1()
        {
            IList<Book> cList = TaskController.GetBookAsync().Result;
            Console.WriteLine(string.Join("\n", cList.ToString()));
            //Fast write out
            for (int i = 0; i < cList.Count; i++)
                Console.WriteLine(cList[i].ToString());
            Console.WriteLine();
        }


        private static void menu2()
        {
            try
            {
                Console.WriteLine("GET Give Isbn number of the book");
                string isbn13 = Console.ReadLine();
                int id = int.Parse(isbn13);
                Book cb = TaskController.GetOneBookAsync1(isbn13).Result;
                Console.WriteLine(cb.ToString());
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.Message);
            }

        }

        private static void menu3()
        {
            Console.WriteLine("POST: Give data for book to be inserted");
            Console.WriteLine("Title: ");
            String title = Console.ReadLine();
            Console.WriteLine("Author: ");
            String author = Console.ReadLine();
            Console.WriteLine("Page Number: ");
            String Pagenr = Console.ReadLine();
            int pages = Int32.Parse(Pagenr);
            Console.WriteLine("Isbn13 number: ");
            String Isbn13 = Console.ReadLine();

            Book newBook = new Book(title, author, pages, Isbn13);
            Book book = TaskController.AddBookAsync(newBook).Result;
            Console.WriteLine("Book inserted");
            Console.WriteLine(book.ToString());
        }
    }
}
