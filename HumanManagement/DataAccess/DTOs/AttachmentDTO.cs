namespace HumanManagement.DataAccess.DTOs
{
    public class AttachmentDTO
    {
        public string? FilePath { get; set; }

        public int? UserId { get; set; }

        public bool? IsApproved { get; set; }
    }
}
