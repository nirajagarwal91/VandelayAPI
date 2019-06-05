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

        public Inventory GetInventoryForWarehouse(int warehouseId, int itemId)
        {
            return _warehouseContext.Inventories.Where(b => b.WarehouseId == warehouseId && b.ItemId == itemId)
                .FirstOrDefault();
        }
        public Warehouse GetWarehouse(int warehouseId)
        {
            return _warehouseContext.Warehouses.FirstOrDefault(a => a.WarehouseId == warehouseId);
        }

        public void AddInventoryForWarehouse(int warehouseId, Inventory inventory)
        {
            var warehouse = GetWarehouse(warehouseId);
            if (warehouse != null)
            {
                var inventoriesForWarehouse = GetInventories(warehouseId);
                var maxInventoryItemId = inventoriesForWarehouse.Select(a => a.ItemId).Max(); 
                inventory.ItemId = maxInventoryItemId + 1;
                inventory.WarehouseId = warehouseId;
                warehouse.Inventories.Add(inventory);
            }
        }

        public void UpdateItem(Inventory inventory)
        {

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
