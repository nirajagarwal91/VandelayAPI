using Microsoft.EntityFrameworkCore;

namespace VandelayWebAPI.Entities
{
    public class WarehouseContext: DbContext
    {
        public WarehouseContext(DbContextOptions<WarehouseContext> options) : base(options)
        {
                
        }

        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
    }
}
