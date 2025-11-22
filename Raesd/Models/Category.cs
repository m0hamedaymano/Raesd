namespace Raesd.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string NameAR { get; set; }
        public string NameEN { get; set; }


        public ICollection<Complaint> Complaints { get; set; }

    }
}
