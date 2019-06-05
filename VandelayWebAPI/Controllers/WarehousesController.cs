﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VandelayWebAPI.Models;
using VandelayWebAPI.Services;

namespace VandelayWebAPI.Controllers
{
    [Route("api/warehouses")]
    [ApiController]
    public class WarehousesController: Controller
    {
        private IFactoryRepository _factoryRepository;
        public WarehousesController(IFactoryRepository factoryRepository)
        {
            _factoryRepository = factoryRepository;
        }


        // GET api/warehouses
        [HttpGet()]
        public IActionResult GetWarehouses()
        {
            var warehousesFromRepo = _factoryRepository.GetWarehouses();
            var warehouses = Mapper.Map<IEnumerable<WarehouseDto>>(warehousesFromRepo);
            return Ok(warehouses);
        }
    }
}
