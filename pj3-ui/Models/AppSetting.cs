﻿namespace pj3_ui.Models
{
    public class AppSetting
    {
        public ApiUrl ApiUrl { get; set; }
        public UserUrl UserUrl { get; set; }
        public string UrlApi { get; set; }
    }
    public class ApiUrl
    {
        public string GetMovies { get; set; }
    }
    public class UserUrl
    {
        public string Login { get; set; }
        public string GetUser { get; set; }
        public string UpdateUser { get; set; }
        public string InsertUser { get; set; }
    }
}
