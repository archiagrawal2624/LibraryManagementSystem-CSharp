namespace LibraryManagementSystem
{
    public class Book : Item
    {
        public string Publisher { get; set; }
        public int Pages { get; set; }

        public override void DisplayDetails()
        {
            Console.WriteLine($"Book: {Title}, Author: {Author}, ISBN: {ISBN}, Publisher: {Publisher}, Pages: {Pages}, Checked Out: {IsCheckedOut}");
        }
    }
}
