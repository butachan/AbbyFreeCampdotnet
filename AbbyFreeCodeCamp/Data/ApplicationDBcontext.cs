using AbbyFreeCodeCamp.Model;
using Microsoft.EntityFrameworkCore;

namespace AbbyFreeCodeCamp.Data
{
    public class ApplicationDBcontext:DbContext
    {
        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options): base(options)
        {

        }
        public DbSet<Category> Category { get; set; }

    }
}
