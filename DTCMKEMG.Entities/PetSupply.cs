using System;
using System.Collections.Generic;

namespace DTCMKEMG.Entities;

public partial class PetSupply
{
    public long Id { get; set; }

    public int PetBrandId { get; set; }

    public string ItemName { get; set; } = null!;

    public decimal? CustomerPrice { get; set; }

    public int? CurrentStock { get; set; }

    public virtual PetBrand PetBrand { get; set; } = null!;
}
