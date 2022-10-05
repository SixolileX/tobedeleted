using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class Category
    {
        [Key]
        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }
        [Display(Name = "Question")]
        [Required(ErrorMessage = "Question is required.")]
        public string QuestionName { get; set; }
        public string OptionName { get; set; }
        public string CategoryName { get; set; }
        //public IEnumerable<SelectListItem> ListofCategory { get; set; }
    }
}
