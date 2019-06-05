using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
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
            if (!_factoryRepository.SaveWarehouse())
            {
                return StatusCode(500, $"Creating an inventory for {warehouseId} failed!");
            }

            var inventoryToReturn = Mapper.Map<InventoryDto>(inventoryEntity);
            return CreatedAtRoute("GetInventoryForWarehouse", new { warehouseId = warehouseId, itemId = inventoryToReturn.ItemId }, inventoryToReturn);
        }

        [HttpPatch("{itemId}")]
        public IActionResult UpdateItem(int warehouseId, int itemId, [FromBody] JsonPatchDocument<InventoryUpdate> inventoryPatchDocument)
        {
            if (inventoryPatchDocument == null)
            {
                return BadRequest();
            }
            if (!_factoryRepository.WarehouseExists(warehouseId))
            {
                return NotFound();
            }

            var inventoryFromWareHouseRepo = _factoryRepository.GetInventoryForWarehouse(warehouseId, itemId);

            if (inventoryFromWareHouseRepo == null)
            {
                var invDto = new InventoryUpdate();
                inventoryPatchDocument.ApplyTo(invDto, ModelState);

                TryValidateModel(invDto);

                if (!ModelState.IsValid)
                {
                    return new UnprocessableEntityObjectResult(ModelState);
                }
                var inventoryToAdd = Mapper.Map<Inventory>(invDto);
                inventoryToAdd.ItemId= itemId;

                _factoryRepository.AddInventoryForWarehouse(warehouseId, inventoryToAdd);
                if (!_factoryRepository.SaveWarehouse())
                {
                    throw new Exception($"Upserting inventory {itemId} for Warehouse {warehouseId} failed on save.");
                }

                var inventoryToReturn = Mapper.Map<InventoryDto>(inventoryToAdd);
                return CreatedAtRoute("GetInventoryForWarehouse", new { warehouseId = warehouseId, itemId = inventoryToReturn.ItemId }, inventoryToReturn);
            }

            var inventoryToPatch = Mapper.Map<InventoryUpdate>(inventoryFromWareHouseRepo);
            inventoryPatchDocument.ApplyTo(inventoryToPatch, ModelState);
            TryValidateModel(inventoryToPatch);

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            Mapper.Map(inventoryToPatch, inventoryFromWareHouseRepo);
            _factoryRepository.UpdateItem(inventoryFromWareHouseRepo);
            if (!_factoryRepository.SaveWarehouse())
            {
                throw new Exception($"Patching inventory {itemId} for Warehouse {warehouseId} failed on save.");
            }

            return NoContent();
        }
    }
}
