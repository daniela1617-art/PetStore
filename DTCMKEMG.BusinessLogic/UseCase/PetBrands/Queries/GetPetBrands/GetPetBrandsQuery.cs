using DTCMKEMG.BusinessLogic.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTCMKEMG.BusinessLogic.UseCase.PetBrand.Queries.GetPetBrands
{
    public record GetPetBrandsQuery() : IRequest<List<PetBrandResponse>>;
}

