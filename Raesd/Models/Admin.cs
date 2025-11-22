namespace Raesd.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string NameEN { get; set; }
        public string NameAR { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } 

        //relation 
        public ICollection<AdS> AdS { get; set; }
    }
}
