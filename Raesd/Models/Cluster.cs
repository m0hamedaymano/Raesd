namespace Raesd.Models
{
    public class Cluster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }

        //relATION  
        public ICollection<Complaint> Complaints { get; set; }
    }
}
