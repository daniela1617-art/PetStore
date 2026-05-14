using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

using DTCMKEMG.BusinessLogic.DTOs;

using DTCMKEMG.BusinessLogic.UseCase.PetSupply.Commands.CreatePetSupply;
using DTCMKEMG.BusinessLogic.UseCase.PetSupply.Commands.UpdatePetSupply;
using DTCMKEMG.BusinessLogic.UseCase.PetSupply.Commands.DeletePetSupply;

using DTCMKEMG.BusinessLogic.UseCase.PetSupply.Queries.GetPetSupplies;
using DTCMKEMG.BusinessLogic.UseCase.PetSupply.Queries.GetPetSupply;

namespace DTCMKEMG.WebApplication.Controllers
{
    public class PetSupplyController : Controller
    {
        private readonly IMediator _mediator;

        public PetSupplyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: PetSupply
        public async Task<IActionResult> Index()
        {
            var petSupplies =
                await _mediator.Send(new GetPetSuppliesQuery());

            if (petSupplies == null)
            {
                return View(new List<PetSupplyResponse>());
            }

            return View(petSupplies);
        }

        // GET: PetSupply/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PetSupply/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            CreatePetSupplyRequest request)
        {
            try
            {
                var result =
                    await _mediator.Send(
                        new CreatePetSupplyCommand(request));

                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(
                    "",
                    "Error al crear Pet Supply");

                return View(request);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return View(request);
            }
        }

        // GET: PetSupply/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            var petSupply =
                await _mediator.Send(
                    new GetPetSupplyQuery(id));

            if (petSupply == null)
            {
                return NotFound();
            }

            var model =
                petSupply.Adapt<UpdatePetSupplyRequest>();

            return View(model);
        }

        // POST: PetSupply/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            UpdatePetSupplyRequest request)
        {
            try
            {
                var result =
                    await _mediator.Send(
                        new UpdatePetSupplyCommand(request));

                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(
                    "",
                    "Error al editar");

                return View(request);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return View(request);
            }
        }

        // GET: PetSupply/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            var petSupply =
                await _mediator.Send(
                    new GetPetSupplyQuery(id));

            if (petSupply == null)
            {
                return NotFound();
            }

            return View(petSupply);
        }

        // POST: PetSupply/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await _mediator.Send(
                new DeletePetSupplyCommand(id));

            return RedirectToAction(nameof(Index));
        }
    }
}