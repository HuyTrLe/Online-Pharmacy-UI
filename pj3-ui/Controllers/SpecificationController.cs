using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using pj3_ui.Models.Feedback;
using pj3_ui.Models.Product;
using pj3_ui.Service.Specification;
using System.Drawing.Printing;

namespace pj3_ui.Controllers
{
    public class SpecificationController : Controller
    {
        private readonly Lazy<ISpecificationService> _specService;
        public SpecificationController(ISpecificationService specService)
        {
            _specService = new Lazy<ISpecificationService>(() => specService);
        }
        public IActionResult IndexAdmin(int page = 1, int pageSize = 10)
        {
            // Get a list of feedback items from your service.
            var specItems = _specService.Value.GetSpecification();

            // Calculate the total number of pages.
            var totalPages = (int)Math.Ceiling((double)specItems.Count() / pageSize);

            // Ensure that the page parameter is within a valid range.
            page = Math.Max(1, Math.Min(totalPages, page));

            // Retrieve the feedback items for the current page.
            var pagedSpecItems = specItems
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Create a view model to pass to the view.
            var viewModel = new SpecificationListViewModel
            {
                SpecsItems = pagedSpecItems,
                CurrentPage = page,
                TotalPages = totalPages
            };

            return View(viewModel);
        }

        public int Update(SpecificationModel spec)
        {
            var result = _specService.Value.UpdateSpecification(spec);
            return result;
        }

        public IActionResult Create()
        {
            return View();
        }

        public int InsertSpecification(SpecificationModel spec)
        {
            var result = _specService.Value.InsertSpecification(spec);
            return result;
        }

        public int DeleteSpecification(SpecificationModel spec)
        {
            var result = _specService.Value.DeleteSpecification(spec);
            return result;
        }

        public int CheckUniqueByName(SpecificationModel spec)
        {
            spec.Name = spec.Name.Replace(" ","");
            var result = _specService.Value.CheckUniqueByName(spec);
            if (result != null)
            {
                return -1;
            }
            return 1;
        }
    }
}
