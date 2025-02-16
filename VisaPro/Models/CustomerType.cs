using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace VisaPro.Models
{
    public class CustomerType
    {
        [Required]
        public int Amount { get; set; }

        [Required]
        public string SelectedOption { get; set; }
        public List<SelectListItem> Options { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "New", Text = "New" },
            new SelectListItem { Value = "Loyal", Text = "Loyal" },
            
        };
    }
    public class CustomerTypeWithDiscount
    {
        public CustomerType CustomerType { get; set; }
        public double Discount { get; set; }
    }
}
