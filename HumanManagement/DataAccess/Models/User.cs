using System;
using System.Collections.Generic;

namespace HumanManagement.DataAccess.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime? RefreshTokenExpired { get; set; }

    public int DaysOffCount { get; set; }

    public int DaysOffLimit { get; set; }

    public double? SalaryPerYear { get; set; }

    public double? FinalSalary { get; set; }

    public int? RoleId { get; set; }

    public virtual ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<Token> Tokens { get; set; } = new List<Token>();

    public virtual ICollection<UsersClaim> UsersClaims { get; set; } = new List<UsersClaim>();
}
