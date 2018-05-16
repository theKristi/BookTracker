using BookTracker.Models.ServiceModels;
using System.ComponentModel.DataAnnotations;


namespace BookTracker.Models.ViewModels
{
    public class BookVM
    {
        public BookVM() {

        }
        public BookVM(BookServiceModel bookServiceModel)
        {
            Id = bookServiceModel.BookID;
            ISBN = bookServiceModel.ISBN;
            Title = bookServiceModel.Title;
            Author = bookServiceModel.Author;
            Synopsis = bookServiceModel.Synopsis;
            Owner = bookServiceModel.Owner.Email;
            CheckedOut = bookServiceModel.CheckedOut?.Email;
        }
        [Required]
        [StringLength(10, ErrorMessage = "ISBN can only be 10 characters")]
        public string ISBN { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }

        public string Author { get; set; }
        public string Synopsis { get; set; }
        public string Owner { get; set; }
        public string CheckedOut { get; set; }
        
    }
}
