namespace Raesd.Models
{
    public class AdS
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        //fk 

        public int AdminId { get; set; }
    }
}
