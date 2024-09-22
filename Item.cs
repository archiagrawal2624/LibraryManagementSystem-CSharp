namespace LibraryManagementSystem
{
    public abstract class Item
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsCheckedOut { get; private set; }

        public void CheckOut() { IsCheckedOut = true; }
        public void Return() { IsCheckedOut = false; }
        public abstract void DisplayDetails();
    }
}
