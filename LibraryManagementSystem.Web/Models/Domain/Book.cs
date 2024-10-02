using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Web.Models.Domain
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Author { get; set; }
        public string ISBN { get; set; }
        public Guid CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category{ get; set; }

        public int? TotalCopies { get; set; } = -1;
        public int? CopiesAvailable { get; set; } = -1;
        public DateOnly CreatedDate { get; set; } = new DateOnly();
        public DateOnly UpdatedDate { get; set; } = new DateOnly();

    }
}
