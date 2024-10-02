using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Web.Models.ViewModel
{
    public class CategoryCreateViewModel
    {
        [DisplayName("Category Name")]
        [Required]
        public string Name { get; set; }
    }
}
