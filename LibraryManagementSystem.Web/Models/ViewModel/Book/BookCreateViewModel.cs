using LibraryManagementSystem.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Web.Models.ViewModel.Book
{
    public class BookCreateViewModel
    {
        [Required]
        public string Title { get; set; }
        public string? Author { get; set; }

        [Required]
        public string ISBN { get; set; }

        [DisplayName("Total Coppies")]
        public int? TotalCopies { get; set; } = -1;
        public List<SelectListItem>? CategoryList { get; set; }

        [Required]
        public Guid CategoryId { get; set; }
    }
}
