using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VandelayWebAPI.Models;
using VandelayWebAPI.Services;

namespace VandelayWebAPI.Controllers
{
    [Route("api/factories")]
    [ApiController]
    public class FactoriesController : Controller
    {
        private IFactoryRepository _factoryRepository;
        public FactoriesController(IFactoryRepository factoryRepository)
        {
            _factoryRepository = factoryRepository;
        }


        // GET api/factories
        [HttpGet()]
        public IActionResult GetFactories()
        {
            var factoriesFromRepo = _factoryRepository.GetFactories();
            var factories = Mapper.Map<IEnumerable<FactoryDto>>(factoriesFromRepo);
            return Ok(factories);   
        }
    }
}
