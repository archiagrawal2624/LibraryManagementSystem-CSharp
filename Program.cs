using System;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            library.LoadData(); // Load existing data from files

            while (true)
            {
                Console.WriteLine("\nLibrary Management System");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Register Member");
                Console.WriteLine("3. Borrow Item");
                Console.WriteLine("4. Return Item");
                Console.WriteLine("5. Display All Items");
                Console.WriteLine("6. Save Data");
                Console.WriteLine("7. Exit");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        library.AddItem();
                        break;
                    case "2":
                        library.RegisterMember();
                        break;
                    case "3":
                        library.BorrowItem();
                        break;
                    case "4":
                        library.ReturnItem();
                        break;
                    case "5":
                        library.DisplayItems();
                        break;
                    case "6":
                        library.SaveData();
                        Console.WriteLine("Data saved successfully.");
                        break;
                    case "7":
                        library.SaveData();
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
