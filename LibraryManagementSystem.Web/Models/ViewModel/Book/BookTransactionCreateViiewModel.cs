using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagementSystem.Web.Models.ViewModel.Book
{
    public class BookTransactionCreateViiewModel
    {
        public Guid BookId { get; set; }
        public List<SelectListItem>? BookList{ get; set; }

        public Guid MemberId { get; set; }
        public List<SelectListItem>? MemberList { get; set; }
    }
}
