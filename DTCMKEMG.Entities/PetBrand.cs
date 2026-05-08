using System;
using System.Collections.Generic;

namespace DTCMKEMG.Entities;
public partial class PetBrand
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<PetSupply> PetSupplies { get; set; } = new List<PetSupply>();
}
