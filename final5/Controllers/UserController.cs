using final5.Models;
using final5.Repositories.IRepos;
using final5.Repositories.Repos;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using System.Security.Claims;

namespace final5.Controllers
{
    public class UsersController: Controller
    {
        private readonly IUserRepository _userRepo;

        public UsersController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        /// <summary>
        /// выводим всех пользователей на страничке .../Users
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var authors = await _userRepo.GetUsers();
            return View(authors);
        }

        /// <summary>
        /// возвращает обычное представление
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// регистрация нового пользователя
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Register(User newUser)
        {
            await _userRepo.AddUser(newUser);
            return View(newUser);
        }

        [HttpGet]
        [Route("authenticate")]
        public async Task<User> Authenticate(string login, string password)
        {
            if (String.IsNullOrEmpty(login)
                || String.IsNullOrEmpty(password))
                throw new ArgumentNullException("Логин или пароль не корректен");

            User user = _userRepo.GetByLogin(login);
            if (user is null)
                throw new AuthenticationException("Пользователь на найден");

            if (user.Password != password)
                throw new AuthenticationException("Введенный пароль не корректен");

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                claims,
                "AppCookie",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return user;
        }
    }
}
