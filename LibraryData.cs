using System;
using System.Collections.Generic;
using System.IO;

namespace LibraryManagementSystem
{
    public static class LibraryData
    {
        private const string ItemsFile = "items.txt";
        private const string MembersFile = "members.txt";

        public static void SaveItems(List<Item> items)
        {
            using (var writer = new StreamWriter(ItemsFile))
            {
                foreach (var item in items)
                {
                    writer.WriteLine($"{item.GetType().Name}|{item.Title}|{item.Author}|{item.ISBN}|{item.IsCheckedOut}");
                    if (item is Book book)
                    {
                        writer.WriteLine($"Publisher|{book.Publisher}|{book.Pages}");
                    }
                    else if (item is Magazine magazine)
                    {
                        writer.WriteLine($"IssueNumber|{magazine.IssueNumber}|{magazine.PublicationDate}");
                    }
                    else if (item is DVD dvd)
                    {
                        writer.WriteLine($"Duration|{dvd.Duration}|{dvd.Director}");
                    }
                }
            }
        }

        public static List<Item> LoadItems()
        {
            var items = new List<Item>();
            if (File.Exists(ItemsFile))
            {
                var lines = File.ReadAllLines(ItemsFile);
                for (int i = 0; i < lines.Length; i++)
                {
                    var parts = lines[i].Split('|');
                    Item item = null;
                    switch (parts[0])
                    {
                        case "Book":
                            item = new Book { Title = parts[1], Author = parts[2], ISBN = parts[3], IsCheckedOut = bool.Parse(parts[4]) };
                            i++;
                            var bookDetails = lines[i].Split('|');
                            ((Book)item).Publisher = bookDetails[1];
                            ((Book)item).Pages = int.Parse(bookDetails[2]);
                            break;
                        case "Magazine":
                            item = new Magazine { Title = parts[1], Author = parts[2], ISBN = parts[3], IsCheckedOut = bool.Parse(parts[4]) };
                            i++;
                            var magazineDetails = lines[i].Split('|');
                            ((Magazine)item).IssueNumber = magazineDetails[1];
                            ((Magazine)item).PublicationDate = DateTime.Parse(magazineDetails[2]);
                            break;
                        case "DVD":
                            item = new DVD { Title = parts[1], Author = parts[2], ISBN = parts[3], IsCheckedOut = bool.Parse(parts[4]) };
                            i++;
                            var dvdDetails = lines[i].Split('|');
                            ((DVD)item).Duration = int.Parse(dvdDetails[1]);
                            ((DVD)item).Director = dvdDetails[2];
                            break;
                    }
                    items.Add(item);
                }
            }
            return items;
        }

        public static void SaveMembers(List<LibraryMember> members)
        {
            using (var writer = new StreamWriter(MembersFile))
            {
                foreach (var member in members)
                {
                    writer.WriteLine($"{member.GetType().Name}|{member.Name}|{member.MembershipID}");
                }
            }
        }

        public static List<LibraryMember> LoadMembers()
        {
            var members = new List<LibraryMember>();
            if (File.Exists(MembersFile))
            {
                var lines = File.ReadAllLines(MembersFile);
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    LibraryMember member = null;
                    if (parts[0] == "StudentMember")
                    {
                        member = new StudentMember { Name = parts[1], MembershipID = int.Parse(parts[2]) };
                    }
                    else if (parts[0] == "FacultyMember")
                    {
                        member = new FacultyMember { Name = parts[1], MembershipID = int.Parse(parts[2]) };
                    }
                    members.Add(member);
                }
            }
            return members;
        }
    }
}
