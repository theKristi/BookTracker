using System.ComponentModel.DataAnnotations;

namespace BookTracker.Models
{
    public class Book
    {
        public int BookID { get; set; }
        [StringLength(10, ErrorMessage = "ISBN can only be 10 characters")]
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Synopsis { get; set; }
        [StringLength(450)]
        public string OwnerID { get; set; }
        [StringLength(450)]
        public string CheckedOutID { get; set; }
        public ApplicationUser Owner { get; set; }
        public ApplicationUser CheckedOut { get; set; }
    }
}
