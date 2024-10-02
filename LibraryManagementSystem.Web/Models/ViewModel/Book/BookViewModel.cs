using LibraryManagementSystem.Web.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Web.Models.ViewModel.Book
{
    public class BookViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int TotalCopies { get; set; }
        public int CopiesAvailable { get; set; }
    }
}
