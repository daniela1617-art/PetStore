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
        public IActionResult Index()
        {
            return View();
        }
    }
}
