using System.Collections.Generic;
using VandelayWebAPI.Entities;

namespace VandelayWebAPI.Services
{
    public interface IFactoryRepository
    {
        IEnumerable<Factory> GetFactories();
        bool FactoryExists(int factoryId);
        IEnumerable<Machine> GetMachines(int factoryId);
        IEnumerable<Warehouse> GetWarehouses();
        bool WarehouseExists(int warehouseId);
        IEnumerable<Inventory> GetInventories(int warehouseId);
        Warehouse GetWarehouse(int warehouseId);
        Inventory GetInventoryForWarehouse(int warehouseId, int itemId);
        void AddInventoryForWarehouse(int warehouseId, Inventory inventory);
        //void UpdateItem(Inventory inventory);
        bool Save();
        bool SaveWarehouse();
    }
}
