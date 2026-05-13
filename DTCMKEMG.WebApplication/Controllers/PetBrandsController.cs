using DTCMKEMG.BusinessLogic.DTOs;
using Mapster;
using DTCMKEMG.BusinessLogic.UseCase.PetBrand.Queries.GetPetBrands;
using DTCMKEMG.BusinessLogic.UseCase.PetBrands.Commands.CreatePetBrand;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DTCMKEMG.BusinessLogic.UseCase.PetBrands.Queries.GetPetBrand;
using DTCMKEMG.BusinessLogic.UseCase.PetBrands.Commands.UpdatePetBrand;
using DTCMKEMG.BusinessLogic.UseCase.PetBrands.Commands.DeletePetBrand;

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
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( CreatePetBrandRequest createBrandRequest)
        {
            try
            {
                var result = await _mediator.Send(new CreatePetBrandCommand (createBrandRequest));
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error la intentar guardar la nueva marca");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(createBrandRequest);
            }

        }
        public async Task<IActionResult> Edit(int id)
        {
            var brand = await _mediator.Send(new GetPetBrandQuery(id));
            return View(brand.Adapt(new UpdatePetBrandRequest()));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdatePetBrandRequest updateBrandRequest)
        {
            try
            {
                var result = await _mediator.Send(new UpdatePetBrandCommand(updateBrandRequest));
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error la intentar editar marca");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(updateBrandRequest);
            }
        }
              public async Task<IActionResult> Delete(int id)
        {
            var brand = await _mediator.Send(new GetPetBrandQuery(id));
            return View(brand);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, PetBrandResponse brandResponse)
        {
            try
            {
                var result = await _mediator.Send(new DeletePetBrandCommand(id));
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error la intentar editar marca");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(brandResponse);
            }
        }
    }
}
