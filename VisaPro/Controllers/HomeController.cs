using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VisaPro.Models;
using Newtonsoft.Json;

namespace VisaPro.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(new CustomerType());
    }

    [HttpPost]
    public IActionResult Index(CustomerType model)
    {
        if (ModelState.IsValid) {
            var customerTypeWithDiscount = new CustomerTypeWithDiscount
            {
                CustomerType = model,
                Discount =  model.Amount> 100 && model.SelectedOption=="Loyal" ? model.Amount * 0.10 : 0
            };
            TempData["CustomerTypewithDiscount"] = JsonConvert.SerializeObject(customerTypeWithDiscount);
            
            return RedirectToAction("Index", "Results");
            //return View(model);
        }
        return View(model);
    }
    

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
