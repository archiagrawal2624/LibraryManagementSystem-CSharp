using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    public class Library
    {
         private List<Item> items = new List<Item>();
        private List<LibraryMember> members = new List<LibraryMember>();

        public void Initialize()
        {
            // Prepopulate with some items
            items.Add(new Book { Title = "1984", Author = "George Orwell", ISBN = "123456789", Publisher = "Secker & Warburg", Pages = 328 });
            items.Add(new Magazine { Title = "National Geographic", Author = "Various", ISBN = "987654321", IssueNumber = "2023-09", PublicationDate = DateTime.Now });
            items.Add(new DVD { Title = "Inception", Director = "Christopher Nolan", ISBN = "111213141", Duration = 148 });
        }

        public void AddItem()
        {
            Console.WriteLine("Enter item type (Book, Magazine, DVD): ");
            var itemType = Console.ReadLine();

            Item newItem = null;
            if (itemType.Equals("Book", StringComparison.OrdinalIgnoreCase))
            {
                newItem = new Book();
            }
            else if (itemType.Equals("Magazine", StringComparison.OrdinalIgnoreCase))
            {
                newItem = new Magazine();
            }
            else if (itemType.Equals("DVD", StringComparison.OrdinalIgnoreCase))
            {
                newItem = new DVD();
            }
            else
            {
                Console.WriteLine("Invalid item type.");
                return;
            }

            Console.WriteLine("Enter Title: ");
            newItem.Title = Console.ReadLine();
            Console.WriteLine("Enter Author: ");
            newItem.Author = Console.ReadLine();
            Console.WriteLine("Enter ISBN: ");
            newItem.ISBN = Console.ReadLine();

            if (newItem is Book book)
            {
                Console.WriteLine("Enter Publisher: ");
                book.Publisher = Console.ReadLine();
                Console.WriteLine("Enter Pages: ");
                book.Pages = int.Parse(Console.ReadLine());
            }
            else if (newItem is Magazine magazine)
            {
                Console.WriteLine("Enter Issue Number: ");
                magazine.IssueNumber = Console.ReadLine();
                Console.WriteLine("Enter Publication Date (yyyy-mm-dd): ");
                magazine.PublicationDate = DateTime.Parse(Console.ReadLine());
            }
            else if (newItem is DVD dvd)
            {
                Console.WriteLine("Enter Duration (in minutes): ");
                dvd.Duration = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Director: ");
                dvd.Director = Console.ReadLine();
            }

            items.Add(newItem);
            Console.WriteLine($"{newItem.Title} has been added to the library.");
        }

        public void RegisterMember()
        {
            Console.WriteLine("Enter member type (Student, Faculty): ");
            var memberType = Console.ReadLine();
            LibraryMember newMember = null;

            if (memberType.Equals("Student", StringComparison.OrdinalIgnoreCase))
            {
                newMember = new StudentMember();
            }
            else if (memberType.Equals("Faculty", StringComparison.OrdinalIgnoreCase))
            {
                newMember = new FacultyMember();
            }
            else
            {
                Console.WriteLine("Invalid member type.");
                return;
            }

            Console.WriteLine("Enter Name: ");
            newMember.Name = Console.ReadLine();
            Console.WriteLine("Enter Membership ID: ");
            newMember.MembershipID = int.Parse(Console.ReadLine());

            members.Add(newMember);
            Console.WriteLine($"{newMember.Name} has been registered as a {memberType} member.");
        }

        public void BorrowItem()
        {
            Console.WriteLine("Enter Member Name: ");
            var memberName = Console.ReadLine();
            var member = members.Find(m => m.Name.Equals(memberName, StringComparison.OrdinalIgnoreCase));

            if (member == null)
            {
                Console.WriteLine("Member not found.");
                return;
            }

            Console.WriteLine("Enter Item Title: ");
            var itemTitle = Console.ReadLine();
            var item = items.Find(i => i.Title.Equals(itemTitle, StringComparison.OrdinalIgnoreCase));

            if (item == null)
            {
                Console.WriteLine("Item not found.");
                return;
            }

            member.BorrowItem(item);
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
