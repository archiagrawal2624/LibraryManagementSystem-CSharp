using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    public class Library
    {
        private List<Item> items = LibraryData.LoadItems();
        private List<LibraryMember> members = LibraryData.LoadMembers();

        public void AddItem()
        {
            // Existing code for adding items...
        }

        public void RegisterMember()
        {
            // Existing code for registering members...
        }

        public void BorrowItem()
        {
            // Existing code for borrowing items...
        }

        public void ReturnItem()
        {
            Console.WriteLine("Enter Item Title: ");
            var itemTitle = Console.ReadLine();
            var item = items.Find(i => i.Title.Equals(itemTitle, StringComparison.OrdinalIgnoreCase));

            if (item == null)
            {
                Console.WriteLine("Item not found.");
                return;
            }

            item.Return();
            Console.WriteLine($"{item.Title} has been returned.");
            // Fine calculation if overdue
            if (item.IsCheckedOut) // Check if it's still checked out (this should be managed with borrow date in a complete system)
            {
                Console.WriteLine("Please enter the date of return (yyyy-mm-dd):");
                DateTime returnDate = DateTime.Parse(Console.ReadLine());
                // Assuming a fixed borrowing period of 14 days
                if (returnDate > DateTime.Now.AddDays(14))
                {
                    Console.WriteLine("This item is overdue. A fine will be applied.");
                }
            }
        }

        public void DisplayItems()
        {
            Console.WriteLine("\nLibrary Items:");
            foreach (var item in items)
            {
                item.DisplayDetails();
            }
        }

        public void SaveData()
        {
            LibraryData.SaveItems(items);
            LibraryData.SaveMembers(members);
        }

        public void LoadData()
        {
            items = LibraryData.LoadItems();
            members = LibraryData.LoadMembers();
        }
    }
}
