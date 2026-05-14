using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

using DTCMKEMG.BusinessLogic.DTOs;

using DTCMKEMG.BusinessLogic.UseCase.User.Commands.CreateUser;
using DTCMKEMG.BusinessLogic.UseCase.User.Commands.UpdateUser;

using DTCMKEMG.BusinessLogic.UseCase.User.Queries.GetUsers;
using DTCMKEMG.BusinessLogic.UseCase.User.Queries.GetUser;

namespace DTCMKEMG.WebApplication.Controllers
{
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var users = await _mediator.Send(new GetPetUsersQuery());

            if (users == null)
            {
                return View(new List<UserResponse>());
            }

            return View(users);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePetUserRequest createUserRequest)
        {
            try
            {
                var result = await _mediator.Send(
                    new CreatePetUserCommand(createUserRequest));

                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", "Error al guardar usuario");
                return View(createUserRequest);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(createUserRequest);
            }
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _mediator.Send(new GetPetUserQuery(id));

            if (user == null)
            {
                return NotFound();
            }

            var model = user.Adapt<UpdateUserRequest>();

            return View(model);
        }

        // POST: Users/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateUserRequest updateUserRequest)
        {
            try
            {
                var result = await _mediator.Send(
                    new UpdatePetUserCommand(updateUserRequest));

                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", "Error al editar usuario");
                return View(updateUserRequest);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(updateUserRequest);
            }
        }
    }
}