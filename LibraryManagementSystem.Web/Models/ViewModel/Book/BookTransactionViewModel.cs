using LibraryManagementSystem.Web.Models.Domain;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LibraryManagementSystem.Web.Models.ViewModel.Book
{
    public class BookTransactionViewModel
    {
        public Guid TransactionId { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnedDate { get; set; }
        public Status Status { get; set; }
        public int PenaltyAmount { get; set; }
        public Guid BookId { get; set; }
        public Guid BookTitle { get; set; }
        public Guid MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberEmail { get; set; }
    }
}
