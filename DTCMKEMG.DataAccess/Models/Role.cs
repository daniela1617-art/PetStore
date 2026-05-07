using System;
using System.Collections.Generic;

namespace DTCMKEMG.DataAccess.Models;

public partial class Role
{
    public int Id { get; set; }

    public string? AccessLevel { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
