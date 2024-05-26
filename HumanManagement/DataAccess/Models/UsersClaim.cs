using System;
using System.Collections.Generic;

namespace HumanManagement.DataAccess.Models;

public partial class UsersClaim
{
    public int UserClaimId { get; set; }

    public int? UserId { get; set; }

    public int? RoleId { get; set; }

    public string? ClaimValue { get; set; }

    public virtual User? User { get; set; }
}
