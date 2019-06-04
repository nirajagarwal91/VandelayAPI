using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VandelayWebAPI.Entities;
using VandelayWebAPI.Models;
using VandelayWebAPI.Services;

namespace VandelayWebAPI.Controllers
{
    [Route("api/warehouses/{warehouseId}/inventories")]
    public class InventoryController: Controller
    {
        private IFactoryRepository _factoryRepository;
        public InventoryController(IFactoryRepository factoryRepository)
        {
            _factoryRepository = factoryRepository;
        }

        [HttpGet()]
        public IActionResult GetInventories(int warehouseId)
        {
            if (!_factoryRepository.WarehouseExists(warehouseId))
            {
                return NotFound();
            }

            var inventoryInWarehouseFromRepo = _factoryRepository.GetInventories(warehouseId);
            var inventoryInWarehouse = Mapper.Map<IEnumerable<InventoryDto>>(inventoryInWarehouseFromRepo);
            return Ok(inventoryInWarehouse);
        }

        [HttpGet("{itemId}", Name = "GetInventoryForWarehouse")]
        public IActionResult GetInventoryForWarehouse(int warehouseId, int itemId)
        {
            if (!_factoryRepository.WarehouseExists(warehouseId))
            {
                return NotFound();
            }

            var inventoryFromWareHouseRepo = _factoryRepository.GetInventoryForWarehouse(warehouseId, itemId);
            if (inventoryFromWareHouseRepo == null)
            {
                return NotFound();
            }

            var bookForAuthor = Mapper.Map<InventoryDto>(inventoryFromWareHouseRepo);
            return Ok(bookForAuthor);
        }

        [HttpPost()]
        public IActionResult AddItem(int warehouseId, [FromBody] InventoryItem inventory)
        {
            if (inventory == null)
            {
                return BadRequest();
            }
            if (!_factoryRepository.WarehouseExists(warehouseId))
            {
                return NotFound();
            }

            var inventoryEntity = Mapper.Map<Inventory>(inventory);

            _factoryRepository.AddInventoryForWarehouse(warehouseId, inventoryEntity);
            if (!_factoryRepository.Save())
            {
                return StatusCode(500, $"Creating an inventory for {warehouseId} failed!");
            }

            var inventoryToReturn = Mapper.Map<InventoryDto>(inventoryEntity);
            return CreatedAtRoute("GetInventoryForWarehouse", new { warehouseId = warehouseId, itemId = inventoryToReturn.ItemId }, inventoryToReturn);
        }

        //[HttpPatch("{warehouseId}")]
        //public IActionResult UpdateItem(int warehouseId, [FromBody] InventoryUpdate inventory)
        //{
        //    if (!_factoryRepository.WarehouseExists(warehouseId))
        //    {
        //        return NotFound();
        //    }

        //    _factoryRepository.updateInventory(inventory);
        //    if (!_factoryRepository.Save())
        //    {
        //        return StatusCode(500, "Updating an inventory failed!");
        //    }
        //    var inventoryInWarehouse = _factoryRepository.GetMachines(warehouseId);
        //    return CreatedAtRoute("GetWarehouse", new { warehouseId = inventoryInWarehouse.warehouseId }, inventoryInWarehouse);
        //}
    }
}
