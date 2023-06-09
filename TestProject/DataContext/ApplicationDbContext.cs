using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TestProject.Models;

namespace TestProject.DataContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        } 

        public DbSet<CategoryInfo> categories { get; set; }

        public DbSet<ProductInfo> products { get; set; }
    }
}
