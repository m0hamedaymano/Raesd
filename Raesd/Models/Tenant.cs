namespace Raesd.Models
{
    public class Tenant
    {
        public int Id { get; set; }
        public string NameEN { get; set; }
        public string NameAR { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
       
        //Relation 
        public ICollection<User> Users { get; set; }

    }
}
