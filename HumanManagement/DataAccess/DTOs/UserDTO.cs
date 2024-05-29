using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HumanManagement.DataAccess.DTOs;

public partial class UserDTO
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

}
