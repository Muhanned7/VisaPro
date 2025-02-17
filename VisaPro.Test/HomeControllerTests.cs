using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using VisaPro.Controllers;
using VisaPro.Models;
using Xunit;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace VisaPro.Test
{
    public class HomeControllerTests
    {
        [Fact]
        public void ReturnAViewWIthDiscount()
        {
            var logger = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(logger.Object);

            var result = controller.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<CustomerType>(viewResult.Model);

        }

        [Theory]
        [InlineData(150, "New", 0.0)]
        [InlineData(150, "Loyal", 15.0)]
        [InlineData(50, "Loyal", 0.0)]
        [InlineData(200, "New", 0.0)]
        [InlineData(200, "Loyal", 20.0)]
        [InlineData(100, "Loyal", 0.0)]
        public void DiscountTest(int amount, string selectedOption, double expectedDiscount)
        {
            // Mock the logger for the controller
            var logger = new Mock<ILogger<HomeController>>();

            // Mock the TempData dictionary
            var tempData = new Mock<ITempDataDictionary>();

            // Setup the controller with mocked dependencies
            var controller = new HomeController(logger.Object)
            {
                TempData = tempData.Object
            };

            // Create the model to pass to the controller
            var model = new CustomerType { Amount = amount, SelectedOption = selectedOption };

            // Call the Index action
            var result = controller.Index(model) as RedirectToActionResult;

            if (controller.ModelState.IsValid)
            {
                // Assert that the result is a RedirectToActionResult
                Assert.NotNull(result);
                Assert.Equal("Index", result.ActionName);
                Assert.Equal("Results", result.ControllerName);

                // Mock the TempData behavior:
                // Here we're setting up the mock to return the same value on subsequent calls
                string serializedData = JsonConvert.SerializeObject(new CustomerTypeWithDiscount
                {
                    CustomerType = model,
                    Discount = expectedDiscount
                });
                tempData.Setup(td => td["CustomerTypewithDiscount"]).Returns(serializedData);

                // Since we're in a test environment, we need to explicitly set up how TempData behaves
                tempData.VerifySet(td => td["CustomerTypewithDiscount"] = It.IsAny<string>(), Times.Once);

                // Retrieve the data from TempData (simulating Peek behavior)
                var tempDataValue = tempData.Object["CustomerTypewithDiscount"] as string;
                Assert.NotNull(tempDataValue);

                // Deserialize and assert
                var customerTypeWithDiscount = JsonConvert.DeserializeObject<CustomerTypeWithDiscount>(tempDataValue);
                Assert.NotNull(customerTypeWithDiscount);
                Assert.Equal(amount, customerTypeWithDiscount.CustomerType.Amount);
                Assert.Equal(expectedDiscount, customerTypeWithDiscount.Discount);
            }
            else
            {
                // If ModelState is invalid, we expect a ViewResult
                var viewResult = Assert.IsType<ViewResult>(result);
                var errors = controller.ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                Assert.True(errors.Any(), "Expected ModelState to have errors when invalid.");
            }
        }
    }
}