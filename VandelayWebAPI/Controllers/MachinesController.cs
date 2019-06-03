using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VandelayWebAPI.Models;
using VandelayWebAPI.Services;

namespace VandelayWebAPI.Controllers
{
    [Route("api/factories/{factoryId}/machines")]
    public class MachinesController: Controller
    {

        private IFactoryRepository _factoryRepository;
        public MachinesController(IFactoryRepository factoryRepository)
        {
            _factoryRepository = factoryRepository;
        }

        [HttpGet()]
        public IActionResult GetMachines(int factoryId)
        {
            if (!_factoryRepository.FactoryExists(factoryId))
            {
                return NotFound();
            }

            var machinesInFactoryFromRepo = _factoryRepository.GetMachines(factoryId);
            var machineInFactory = Mapper.Map<IEnumerable<MachineDto>>(machinesInFactoryFromRepo);
            return Ok(machineInFactory);
        }
    }
}
