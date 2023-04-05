using BlogApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.AppContext
{
    public class BlogContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserPost> Posts { get; set; }
        public DbSet<Request> Requests { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options):base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

    }
}
