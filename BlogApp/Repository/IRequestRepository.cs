using BlogApp.Models;

namespace BlogApp.Repository
{
    public interface IRequestRepository
    {
        Task AddRequest(Request request, string url);
        Task<Request[]>GetRequests();
    }
}
