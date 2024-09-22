namespace LibraryManagementSystem
{
    public class StudentMember : LibraryMember
    {
        public override void BorrowItem(Item item)
        {
            if (!item.IsCheckedOut)
            {
                item.CheckOut();
                Console.WriteLine($"{Name} borrowed {item.Title}");
            }
            else
            {
                Console.WriteLine($"{item.Title} is already checked out.");
            }
        }
    }
}
