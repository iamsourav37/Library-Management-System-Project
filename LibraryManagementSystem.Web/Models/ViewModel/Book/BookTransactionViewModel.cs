using LibraryManagementSystem.Web.Models.Domain;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel;

namespace LibraryManagementSystem.Web.Models.ViewModel.Book
{
    public class BookTransactionViewModel
    {
        public Guid TransactionId { get; set; }
        [DisplayName("Borrowed Date")]
        public DateTime BorrowedDate { get; set; }
        public DateTime DueDate { get; set; }
        [DisplayName("Returned Date")]
        public DateTime? ReturnedDate { get; set; }
        public Status Status { get; set; }
        [DisplayName("Penalty Amount")]
        public int? PenaltyAmount { get; set; }

        [DisplayName("Penalty Days")]
        public int? PenaltyDays { get; set; }
        public Guid BookId { get; set; }
        [DisplayName("Book Title")]
        public string BookTitle { get; set; }
        public Guid MemberId { get; set; }
        [DisplayName("Member Name")]
        public string MemberName { get; set; }
        public string MemberEmail { get; set; }
    }
}
