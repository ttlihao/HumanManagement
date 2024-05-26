using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HumanManagement.DataAccess.DTOs;

public partial class UserDTO
{
    public string userName { get; set; }

    public string password { get; set; }
}
