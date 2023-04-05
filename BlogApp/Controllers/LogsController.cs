using BlogApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class LogsController : Controller
    {
        //private readonly IRequestRepository _repo;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public LogsController(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                // var requests = await _repo.GetRequests();
                var repo = scope.ServiceProvider.GetService<IRequestRepository>();
                var requests = await repo.GetRequests();
                
                return View(requests);
            }
        }
    }
}
