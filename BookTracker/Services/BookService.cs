
using BookTracker.Models;
using BookTracker.Models.ServiceModels;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace BookTracker.Services
{
    public interface IBookService
    {
        IEnumerable<BookServiceModel> GetAllBooks(UserManager<ApplicationUser> userManager);
        BookServiceModel CreateBook(BookServiceModel model);
        BookServiceModel RemoveBook(ApplicationUser owner, BookServiceModel model);
        IEnumerable<BookServiceModel> GetBooksOwnedBy(ApplicationUser owner);
        BookServiceModel CheckOut(ApplicationUser toCheckOut, BookServiceModel model);
        BookServiceModel CheckIn(BookServiceModel book);

    }
    internal class BookService:IBookService
    {
        protected readonly IRepository<Book, int> _repo;
        public BookService(IRepository<Book, int> repository) {
            _repo = repository;
        }

        public BookServiceModel CheckIn(BookServiceModel book)
        {
            throw new System.NotImplementedException();
        }

        public BookServiceModel CheckOut(ApplicationUser toCheckOut, BookServiceModel model)
        {
            throw new System.NotImplementedException();
        }

        public BookServiceModel CreateBook( BookServiceModel model)
        {
           
            var data = _repo.Create(model.ToDataModel());
            _repo.SaveChanges();
            return new BookServiceModel(data);
        }

        public IEnumerable<BookServiceModel> GetAllBooks(UserManager<ApplicationUser> userManager)
        {
            var bookDataModels = _repo.All().ToList();
            foreach (var book in bookDataModels)
            {
                book.Owner = userManager.FindByIdAsync(book.OwnerID).Result;
            }
            return bookDataModels.Select(x => new BookServiceModel(x));
        }

        public IEnumerable<BookServiceModel> GetBooksOwnedBy(ApplicationUser owner)
        {
           return _repo.All().Where(b => b.OwnerID == owner.Id).ToList().Select(x => new BookServiceModel(x));
        }

        public BookServiceModel RemoveBook(ApplicationUser owner, BookServiceModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}
