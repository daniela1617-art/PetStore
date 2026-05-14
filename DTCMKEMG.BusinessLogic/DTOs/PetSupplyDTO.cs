using System;
using System.Collections.Generic;
using System.Text;

namespace DTCMKEMG.BusinessLogic.DTOs
{
    public class PetSupplyResponse
    {
        public long Id { get; set; }

        public int PetBrandId { get; set; }

        public string? ItemName { get; set; }

        public decimal? CustomerPrice { get; set; }

        public int? CurrentStock { get; set; }
    }

    public class CreatePetSupplyRequest
    {
        public int PetBrandId { get; set; }

        public string? ItemName { get; set; }

        public decimal? CustomerPrice { get; set; }

        public int? CurrentStock { get; set; }
    }

    public class UpdatePetSupplyRequest
    {
        public long Id { get; set; }

        public int PetBrandId { get; set; }

        public string? ItemName { get; set; }

        public decimal? CustomerPrice { get; set; }

        public int? CurrentStock { get; set; }
    }

    public class PetSupplyByIdResponse
    {
        public long Id { get; set; }

        public int PetBrandId { get; set; }

        public string? ItemName { get; set; }

        public decimal? CustomerPrice { get; set; }

        public int? CurrentStock { get; set; }
    }
}