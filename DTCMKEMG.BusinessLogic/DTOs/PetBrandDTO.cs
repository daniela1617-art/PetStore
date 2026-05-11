using System;
using System.Collections.Generic;
using System.Text;

namespace DTCMKEMG.BusinessLogic.DTOs
{
    public class PetBrandResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
    public class CreatePetBrandRequest
    {
        public string Name { get; set; } = null!;
    }

}
