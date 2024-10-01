using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Web.Models.Domain
{
    public class RequestMember
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string RawPassword { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address1 { get; set; }
    }
}
