using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Web.Models.Domain
{
    public enum Status
    {
        Borrowed, Returned, Overdue
    }
    public class BookTransaction
    {
        [Key]
        public Guid TransactionId { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public Status Status { get; set; }
        public int? PenaltyAmount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }

        public Guid BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }

        public Guid MemberId { get; set; }

        [ForeignKey(nameof(MemberId))]
        public ApplicationUser Member { get; set; }

    }
}
