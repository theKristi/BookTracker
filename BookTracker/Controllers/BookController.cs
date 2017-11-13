using BookTracker.Models;
using BookTracker.Models.ViewModels;
using BookTracker.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using BookTracker.Models.ServiceModels;
using Microsoft.AspNetCore.Authorization;

namespace BookTracker.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly UserManager<ApplicationUser> _userManager;

       
        public BookController(IBookService service, UserManager<ApplicationUser> userManager) {
            _bookService = service;
            _userManager = userManager;
        }

        public IActionResult Library()
        {
            var serviceModels = _bookService.GetAllBooks(_userManager);
            ViewBag.Title = "Library";
            var vm = serviceModels.Select(x => new BookVM(x));
            return View("ListBooks", vm);
        }

        public  IActionResult ListMyBooks()
        {
            var user = GetUser();
            var serviceModels=_bookService.GetBooksOwnedBy(user.Result);
            var vm = serviceModels.Select(x => new BookVM(x));
            ViewBag.Title = "My Books";
            return PartialView("ListBooks", vm);
        }
        public IActionResult ListAllBooks()
        {
            var serviceModels=_bookService.GetAllBooks(_userManager);
            ViewBag.Title = "Library";
            var vm = serviceModels.Select(x => new BookVM(x));
            return PartialView("ListBooks", vm);

        }
        public IActionResult AddBook() {
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddBook(BookVM vm)
        {
            if (ModelState.IsValid)
            {
                var user = GetUser();
                _bookService.CreateBook(new BookServiceModel(vm, user.Result));
                return RedirectToAction("ListMyBooks");
            }
            return PartialView(vm);
        }

        private async Task<ApplicationUser> GetUser() {
            var user = await _userManager.GetUserAsync(User);
            return user;
        }


    }
}