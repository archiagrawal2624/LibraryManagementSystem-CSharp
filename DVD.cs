namespace LibraryManagementSystem
{
    public class DVD : Item
    {
        public int Duration { get; set; } // Duration in minutes
        public string Director { get; set; }

        public override void DisplayDetails()
        {
            Console.WriteLine($"DVD: {Title}, Director: {Director}, ISBN: {ISBN}, Duration: {Duration} mins, Checked Out: {IsCheckedOut}");
        }
    }
}
