using WebAPILearnings.Models;

namespace WebAPILearnings.Data
{
    public class DataContext : DbContext
    { 
       public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<SuperHero> superHeroes { get; set; }
    }
}
