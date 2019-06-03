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
        bool Save();
    }
}
