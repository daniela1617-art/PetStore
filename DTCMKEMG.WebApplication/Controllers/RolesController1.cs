using DTCMKEMG.BusinessLogic.DTOs;
using DTCMKEMG.BusinessLogic.UseCase.PetBrands.Commands.DeletePetBrand;
using DTCMKEMG.BusinessLogic.UseCase.Roles.Commands.CreateRole;
using DTCMKEMG.BusinessLogic.UseCase.Roles.Commands.UpdateRole;
using DTCMKEMG.BusinessLogic.UseCase.Roles.Queries.GetRole;
using DTCMKEMG.BusinessLogic.UseCase.Roles.Queries.GetRoles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DTCMKEMG.WebApplication.Controllers
{
    public class RolesController : Controller
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // LISTAR
        public async Task<IActionResult> Index()
        {
            var roles = await _mediator.Send(new GetRolesQuery());
            return View(roles);
        }

        // DETALLE
        public async Task<IActionResult> Details(int id)
        {
            var role = await _mediator.Send(new GetRoleQuery(id));

            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // CREAR
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateRoleRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            await _mediator.Send(new CreateRoleCommand(request));

            return RedirectToAction(nameof(Index));
        }

        // EDITAR
        public async Task<IActionResult> Edit(int id)
        {
            var role = await _mediator.Send(new GetRoleQuery(id));

            if (role == null)
            {
                return NotFound();
            }

            var request = new UpdateRoleRequest
            {
                Id = role.Id,
                Name = role.Name
            };

            return View(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateRoleRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            await _mediator.Send(new UpdateRoleCommand(request));

            return RedirectToAction(nameof(Index));
        }

        // ELIMINAR
        public async Task<IActionResult> Delete(int id)
        {
            var role = await _mediator.Send(new GetRoleQuery(id));

            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _mediator.Send(new DeleteRoleCommand(id));

            return RedirectToAction(nameof(Index));
        }
    }
}