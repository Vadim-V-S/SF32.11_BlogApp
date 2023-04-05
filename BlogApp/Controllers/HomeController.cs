using BlogApp.Models;
using BlogApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogRepository _repo;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IBlogRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            //var user = new User()
            //{
            //    Id = Guid.NewGuid(),
            //    FirstName = "Петя",
            //    LastName = "Смирнов",
            //    JoinTime = DateTime.Now,
            //};

            //await _repo.AddUser(user);

            //Console.WriteLine($"User {user.FirstName} was added to the user's list at {user.JoinTime}");

            return View();
        }

        //public async Task<IActionResult> Authors()
        //{
        //    var authors = await _repo.GetUsers();
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