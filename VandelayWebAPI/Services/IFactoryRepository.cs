using System.Collections.Generic;
using VandelayWebAPI.Entities;

namespace VandelayWebAPI.Services
{
    public interface IFactoryRepository
    {
        IEnumerable<Factory> GetFactories();
        //Factory GetFactory(int factoryId);
        bool FactoryExists(int factoryId);
        IEnumerable<Machine> GetMachines(int factoryId);

        IEnumerable<Warehouse> GetWarehouses();

        bool WarehouseExists(int warehouseId);
        IEnumerable<Inventory> GetInventories(int warehouseId);
        bool Save();
        bool SaveWarehouse();
    }
}
