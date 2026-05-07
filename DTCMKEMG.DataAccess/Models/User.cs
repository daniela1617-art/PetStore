using System;
using System.Collections.Generic;

namespace DTCMKEMG.DataAccess.Models;

public partial class User
{
    public int Id { get; set; }

    public int RoleId { get; set; }

    public string Username { get; set; } = null!;

    public string? PasswordHash { get; set; }

    public virtual Role Role { get; set; } = null!;
}
