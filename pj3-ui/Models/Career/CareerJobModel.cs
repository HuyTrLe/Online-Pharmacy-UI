namespace pj3_ui.Models.Career
{
    public class CareerJobModel
    {
        public int ID { get; set; }
        public int JobID { get; set; }
        public int UserID { get; set; }
        public int Status { get; set; }
        
    }
    public class CareerJobGet
    {
        public int JobID { get; set; }
    }
    public class CareerUser
    {
        public int UserID { get; set; }
    }
}
