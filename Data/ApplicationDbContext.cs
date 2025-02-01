using Microsoft.EntityFrameworkCore;
using ProductCRUD.Models;


namespace ProductCRUD.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) 
            :base(options)
        { 
        }

        public DbSet <Product> Productss { get; set; }

    }
}
