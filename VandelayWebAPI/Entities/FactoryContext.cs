using Microsoft.EntityFrameworkCore;

namespace VandelayWebAPI.Entities
{
    public class FactoryContext : DbContext
    {
        public FactoryContext(DbContextOptions<FactoryContext> options)
            :base(options)
        {
            //Database.Migrate();

        }

        public DbSet<Factory> Factories { get; set; }
        public DbSet<Machine> Machines { get; set; }
    }
}
