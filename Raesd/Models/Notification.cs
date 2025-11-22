namespace Raesd.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }

        //fk 
        public int UserId { get; set; }

    }
}
