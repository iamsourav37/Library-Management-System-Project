using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Web.Models.ViewModel.Book
{
    public class BookUpdateViewModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        [Required]
        public string ISBN { get; set; }

        public List<SelectListItem>? CategoryList { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        [Required]
        [DisplayName("Total Copies")]
        public int TotalCopies { get; set; }
    }
}
