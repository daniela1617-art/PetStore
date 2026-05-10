using DTCMKEMG.BusinessLogic.UseCase.PetBrand.Queries.GetPetBrands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DTCMKEMG.WebApplication.Controllers
{
    public class PetBrandsController : Controller
    {
        private readonly IMediator _mediator;
        public PetBrandsController(IMediator media)
        {
            _mediator = media;
        } 
        public async Task<IActionResult> Index()
        {
            var brands = await _mediator.Send(new GetPetBrandsQuery());
            return View(brands);
        }
    }
}
 