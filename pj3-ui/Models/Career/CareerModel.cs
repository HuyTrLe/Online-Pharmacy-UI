﻿using pj3_ui.Models.User;

namespace pj3_ui.Models.Career
{
    public class CareerModel
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get;set; }
        public string Position { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Skill { get; set; } = string.Empty;
        public int Status { get; set; }
        public int UserID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int? StatusJob { get; set; }
    }
    public class CareerGet
    {
        public int ID { get; set; }
        public int UserID { get; set; }
    }
    public class CareerJob
    {
        public int CareerJobID { get; set; }
        public int Status { get; set; }
        public CareerModel CareerModel { get; set; }
        public UserModel UserModel { get; set; }
    }
    public class UpdateStatusCareer
    {
        public int CareerJobID { get; set; }
        public int Status { get; set; }
      
    }
    public class UpdateStatusCareerJob
    {
        public int CareerJobID { get; set; }
        public int Status { get; set; }

    }
}
