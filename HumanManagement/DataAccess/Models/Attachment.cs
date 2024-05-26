using System;
using System.Collections.Generic;

namespace HumanManagement.Models;

public partial class Attachment
{
    public int Aid { get; set; }

    public string? FilePath { get; set; }

    public int? UserId { get; set; }

    public bool? IsApproved { get; set; }

    public virtual User? User { get; set; }
}
