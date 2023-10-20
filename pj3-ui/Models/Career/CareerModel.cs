namespace pj3_ui.Models.Career
{
    public class CareerModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; } 
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get;set; }
        public string Position { get; set; }
        public int Price { get; set; }
        public string Skill { get; set; }
        public int Status { get; set; }
        public int UserID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? StatusJob { get; set; }
    }
    public class CareerGet
    {
        public int ID { get; set; }
        public int UserID { get; set; }
    }
}
