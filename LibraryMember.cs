namespace LibraryManagementSystem
{
    public abstract class LibraryMember
    {
        public string Name { get; set; }
        public int MembershipID { get; set; }

        public abstract void BorrowItem(Item item);
    }
}
