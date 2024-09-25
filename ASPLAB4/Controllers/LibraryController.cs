using ASPLAB4.Services;
using ASPLAB4.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASPLAB4.Controllers
{
    public class LibraryController : Controller
    {
        private readonly IUserService _userService; 
        private readonly IBookService _bookService; 
        public LibraryController(IUserService userService, IBookService bookService)
        {
            _userService = userService;
            _bookService = bookService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Books() 
        {
            var books = _bookService.GetBooks();
            return View(books);
        }

        public IActionResult Profile(int? id) 
        {
            if (id.HasValue && id.Value >= 0 && id.Value <= 5)
            {
                var user = _userService.GetUserById(id.Value);
                if (user != null)
                {
                    return View(user);
                }
                return Content("Користувача з таким ID не існує.");
            }
            else
            {
                var currentUser = _userService.GetUserById(0);
                return View(currentUser);
            }
        }
    }
}
