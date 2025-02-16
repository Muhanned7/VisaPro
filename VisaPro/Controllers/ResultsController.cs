using Microsoft.AspNetCore.Mvc;
using VisaPro.Models;
using Newtonsoft.Json;

namespace VisaPro.Controllers
{
    public class ResultsController : Controller
    {
        public IActionResult Index()
        {
            if (TempData["CustomerTypewithDiscount"] != null)
            {
                var customerTypeJson = TempData["CustomerTypewithDiscount"].ToString();
                var customerType = JsonConvert.DeserializeObject<CustomerTypeWithDiscount>(customerTypeJson);
                return View(customerType);
            }
            return View();
        }
    }
}

