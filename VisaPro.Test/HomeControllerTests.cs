using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using VisaPro.Controllers;
using VisaPro.Models;
using Xunit;
using Newtonsoft.Json;

namespace VisaPro.Test
{
    public class HomeControllerTests
    {
        [Fact]
        public void ReturnAViewWIthDiscount()
        {
            var logger =new  Mock<ILogger<HomeController>>();
            var controller = new HomeController(logger.Object);

            var result = controller.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<CustomerType>(viewResult.Model);

        }


        public void DiscountTest()
        {
            var logger = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(logger.Object);
            //var result = controller.Index();
            var result = controller.Index(new CustomerType { Amount = 150, SelectedOption="New" });
            var tempData = controller.TempData["CustomerTypewithDiscount"] as string;
            Assert.NotNull(tempData);

            var customerTypeWithDiscount = JsonConvert.DeserializeObject<CustomerTypeWithDiscount>(tempData);
            Assert.Equal(150, customerTypeWithDiscount.CustomerType.Amount);
            Assert.Equal(15, customerTypeWithDiscount.Discount);
        } 

    }
}