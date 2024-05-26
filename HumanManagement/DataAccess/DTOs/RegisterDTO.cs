namespace HumanManagement.DataAccess.DTOs
{
    public class RegisterDTO
    {
        public string? userName { get; set; }

        public string? password { get; set; }

        public string phoneNumber { get; set; }

        public int roleID { get; set; } = 2;
    }
}
