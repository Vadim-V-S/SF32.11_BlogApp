using BlogApp.AppContext;
using BlogApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private readonly BlogContext _context;

        public RequestRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task AddRequest(Request request, string url)
        {
            request.Id = Guid.NewGuid();
            request.Date = DateTime.Now;
            request.Url = url;

            var entry = _context.Entry(request);

            if (entry.State == EntityState.Detached)
            {
                await _context.AddAsync(request);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Request[]> GetRequests()
        {
            var requests = await _context.Requests.ToArrayAsync();
            return requests.OrderBy(x => x.Date).ToArray();
        }
    }
}
