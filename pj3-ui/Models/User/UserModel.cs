namespace pj3_ui.Models.User
{
    public class UserModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public string Education { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
