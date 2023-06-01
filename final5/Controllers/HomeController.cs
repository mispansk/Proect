using final5.Models;
using final5.Repositories.IRepos;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace final5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _userRepo;

        public HomeController(ILogger<HomeController> logger, IUserRepository userRepo)
        {
            _logger = logger;
            _userRepo = userRepo;
        }


        //public async Task <IActionResult> Index()
        //{
        //    // Добавим создание нового пользователя
        //    //var newUser = new User()
        //    //{
        //    //    Id = Guid.NewGuid(),
        //    //    FirstName = "Andrey",
        //    //    LastName = "Petrov",
        //    //    Password = "123",
        //    //    Email = "asd",
        //    //    Login = "456"
                
                
        //    //};

        //    // Добавим в базу
        //    await _userRepo.AddUser(newUser);

        //    // Выведем результат
        //    Console.WriteLine($"User with id {newUser.Id}, named {newUser.FirstName} was successfully added");

        //    return View();
        //}

        //public async Task<IActionResult> Authors()
        //{
        //    var authors = await _userRepo.GetUsers();

        //    //Console.WriteLine("See all blog authors:");
        //    //foreach (var author in authors)
        //    //    Console.WriteLine($"Author name {author.FirstName}");

        //    return View(authors);
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}