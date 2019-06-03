using Microsoft.AspNetCore.Mvc;

namespace VandelayWebAPI.Controllers
{
    [Route("api/warehouses/{warehouseId}/inventory")]
    public class InventoryController: Controller
    {
        //private IFactoryRepository _factoryRepository;
        //public InventoryController(IFactoryRepository factoryRepository)
        //{
        //    _factoryRepository = factoryRepository;
        //}

        //[HttpGet("{warehouseId}", Name="GetWarehouse")]
        //public IActionResult GetWarehouse(int warehouseId)
        //{
        //    if (!_factoryRepository.WarehouseExists(warehouseId))
        //    {
        //        return NotFound();
        //    }

        //    var inventoryInWarehouse = _factoryRepository.GetMachines(warehouseId);
        //    return Ok(inventoryInWarehouse);
        //}

        //[HttpPost("{warehouseId}")]
        //public IActionResult AddItem(int warehouseId, [FromBody] InventoryItem inventory)
        //{ 
        //    if (inventory == null)
        //    {
        //        return BadRequest();
        //    }
        //    if (!_factoryRepository.WarehouseExists(warehouseId))
        //    {
        //        return NotFound();
        //    }

        //    _factoryRepository.AddInventory(warehouseId, inventory);
        //    if (!_factoryRepository.Save())
        //    {
        //        return StatusCode(500, $"Creating an inventory for {warehouseId} failed!");
        //    }
        //    var inventoryInWarehouse = _factoryRepository.GetMachines(warehouseId);
        //    return CreatedAtRoute("GetWarehouse", new { warehouseId = inventoryInWarehouse.warehouseId }, inventoryInWarehouse );
        //}

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
