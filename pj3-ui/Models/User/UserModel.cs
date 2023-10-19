namespace pj3_ui.Models.User
{
    public class UserModel
    {
        public int ID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int RoleID { get; set; }
        public string FileName { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
    public class Login
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class ChangePassword
    {
        public int UserID { get; set; }
        public string Password { get; set; }
    }
    public class Upload
    {
       public IFormFile PdfFile { get; set; }
    }
    public class UploadFile
    {
        public int UserID { get; set; }
        public string Filename { get; set; }
    }
    public class DeleteEducation
    {
       public List<string> listID { get; set; }
    }
}
