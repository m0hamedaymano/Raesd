namespace Raesd.Models
{
    public class Complaint
    {
        public int Id { get; set; }
        public string DescriptionAR { get; set; }
        public string DescriptionEN { get; set; }
        public string Image {  get; set; }
        public string Video { get; set; }
        public string Status { get; set; }
        public double Lat {  get; set; }
        public double Lng { get; set; }
        public string Location { get; set; }

        public string AiGeniratiedText { get; set; }
        public string SerialNumber { get; set; }

        //Relations
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int ClusterId { get; set; }




    }
}
