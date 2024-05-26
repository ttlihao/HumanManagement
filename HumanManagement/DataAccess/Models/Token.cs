using System;
using System.Collections.Generic;

namespace HumanManagement.DataAccess.Models;

public partial class Token
{
    public int Id { get; set; }

    public string? TokenString { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
