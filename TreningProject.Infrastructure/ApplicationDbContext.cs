using Microsoft.EntityFrameworkCore;
using TreningProject.Abstractions;

namespace TreningProject.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<WeatherCondition> WeatherConditions { get; set; }
    }
}
