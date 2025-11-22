namespace Raesd.Models
{
    public class User
    {
        public int Id { get; set; }
        public int SSN { get; set; }
        public string FullNameAR {  get; set; }
        public string FullNameEN { get; set; }
        public string Email {  get; set; }
        public string Password { get; set; }
        public int PhNumber { get; set; }
        public string UserType { get; set; }
        public string PlatNumber { get; set; }

        //FK
        public int TenantId { get; set; }

        //relation 
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Complaint> Complaints { get; set; }


    }
}
