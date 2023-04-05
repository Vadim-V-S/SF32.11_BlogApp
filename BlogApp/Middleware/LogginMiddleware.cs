using BlogApp.Repository;

namespace BlogApp.Middleware
{
    public class LogginMiddleware
    {
        private readonly RequestDelegate _next;

        public LogginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            using (var scope = context.RequestServices.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<IRequestRepository>();
                string url = context.Request.Host.Value + context.Request.Path;
                
                await repo.AddRequest(new Models.Request(), url);
            }
            await _next.Invoke(context);
        }
    }
}
