using System.ComponentModel.DataAnnotations;
using BookTracker.Models.ViewModels;

namespace BookTracker.Models.ServiceModels
{
    public class BookServiceModel
    {
        public BookServiceModel(Book book) {

            BookID = book.BookID;
            ISBN = book.ISBN;
            Title = book.Title;
            Author = book.Author;
            Synopsis = book.Synopsis;
            Owner = book.Owner;
            OwnerID = book.OwnerID;
            CheckedOut = book.CheckedOut;

        }

        public BookServiceModel(BookVM book, ApplicationUser owner)
        {
            ISBN = book.ISBN;
            Title = book.Title;
            Author = book.Author;
            Synopsis = book.Synopsis;
            Owner = owner;
        }

        public int BookID { get; set; }
        [StringLength(10, ErrorMessage = "ISBN can only be 10 characters")]
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Synopsis { get; set; }
        public string OwnerID { get; set; }
        public ApplicationUser Owner { get; set; }
        public ApplicationUser CheckedOut { get; set; }

        public Book ToDataModel() {
            return new Book
            {
                BookID = this.BookID,
                ISBN = this.ISBN,
                Title = this.Title,
                Author = this.Author,
                Synopsis = this.Synopsis,
                OwnerID = this.Owner.Id,
                CheckedOutID = this.CheckedOut?.Id

            };
        }
    }
}
