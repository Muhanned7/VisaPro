using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace VisaPro.Models
{
    public class CustomerType
    {
        [Required (ErrorMessage ="Amount is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public int Amount { get; set; }

        [Required (ErrorMessage ="Please Select an option")]
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
