namespace LibraryManagementSystem
{
    public class Magazine : Item
    {
        public string IssueNumber { get; set; }
        public DateTime PublicationDate { get; set; }

        public override void DisplayDetails()
        {
            Console.WriteLine($"Magazine: {Title}, Author: {Author}, ISBN: {ISBN}, Issue: {IssueNumber}, Publication Date: {PublicationDate.ToShortDateString()}, Checked Out: {IsCheckedOut}");
        }
    }
}
