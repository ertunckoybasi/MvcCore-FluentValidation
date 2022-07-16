using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcCore_FluentValidation.Extensions;
using MvcCore_FluentValidation.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MvcCore_FluentValidation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IValidator<Employee> _validator;

        public HomeController(ILogger<HomeController> logger, IValidator<Employee> validator)
        {
            _logger = logger;
            _validator = validator;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            ValidationResult result = await _validator.ValidateAsync(employee);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View("CreateEmployee", employee);
            }

            //TODO: Save the data to the database, or some other logic.

            TempData["notice"] = "Employee successfully created, Başarıyla Kaydedildi!";
            return RedirectToAction("Index");
        }

    }
}
