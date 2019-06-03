using System.Collections.Generic;
using System.Linq;
using VandelayWebAPI.Entities;

namespace VandelayWebAPI.Services
{
    public class FactoryRepository: IFactoryRepository
    {
        private FactoryContext _context;

        public FactoryRepository(FactoryContext context)
        {
            _context = context;
        }

        public bool FactoryExists(int factoryId)
        {
            return _context.Factories.Any(a => a.FactoryId == factoryId);
        }
        public IEnumerable<Factory> GetFactories()
        {
            return _context.Factories
                .OrderBy(a => a.FactoryId)
                .ToList();
        }

        public IEnumerable<Machine> GetMachines(int factoryId)
        {
            return _context.Machines
                .Where(b => b.FactoryId == factoryId).OrderBy(b => b.MachineName).ToList();
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
