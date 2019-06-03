using System.Collections.Generic;
using System.Linq;
using VandelayWebAPI.Entities;

namespace VandelayWebAPI.Services
{
    public class FactoryRepository: IFactoryRepository
    {
        private FactoryContext _context;
        private WarehouseContext _warehouseContext;

        public FactoryRepository(FactoryContext context, WarehouseContext warehouseContext)
        {
            _context = context;
            _warehouseContext = warehouseContext;
        }

        public bool FactoryExists(int factoryId)
        {
            return _context.Factories.Any(a => a.FactoryId == factoryId);
        }

        public bool WarehouseExists(int warehouseId)
        {
            return _warehouseContext.Warehouses.Any(a => a.WarehouseId == warehouseId);
        }

        public IEnumerable<Factory> GetFactories()
        {
            return _context.Factories
                .OrderBy(a => a.FactoryId)
                .ToList();
        }

        public IEnumerable<Warehouse> GetWarehouses()
        {
            return _warehouseContext.Warehouses
                .OrderBy(a => a.WarehouseId)
                .ToList();
        }

        public IEnumerable<Machine> GetMachines(int factoryId)
        {
            return _context.Machines
                .Where(b => b.FactoryId == factoryId).OrderBy(b => b.MachineName).ToList();
        }

        public IEnumerable<Inventory> GetInventories(int warehouseId)
        {
            return _warehouseContext.Inventories
                .Where(b => b.ItemDelete == false).OrderBy(b => b.ItemId).ToList();
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
        public bool SaveWarehouse()
        {
            return (_warehouseContext.SaveChanges() >= 0);
        }
    }
}
