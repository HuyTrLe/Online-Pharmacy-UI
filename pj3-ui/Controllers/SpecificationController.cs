using Microsoft.AspNetCore.Mvc;
using pj3_ui.Service.Specification;

namespace pj3_ui.Controllers
{
    public class SpecificationController : Controller
    {
        private readonly Lazy<ISpecificationService> _specificationService;
        public SpecificationController(ISpecificationService specificationService)
        {
            _specificationService = new Lazy<ISpecificationService>(() => specificationService);
        }

        public IActionResult IndexAdmin()
        {
            var result = _specificationService.Value.GetSpecification();
            return View(result);
        }
    }
}
