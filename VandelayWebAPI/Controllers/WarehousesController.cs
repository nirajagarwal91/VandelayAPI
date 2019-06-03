using Microsoft.AspNetCore.Mvc;

namespace VandelayWebAPI.Controllers
{
    [Route("api/warehouses")]
    public class WarehousesController: Controller
    {
        //private IFactoryRepository _factoryRepository;
        //public WarehousesController(IFactoryRepository factoryRepository)
        //{
        //    _factoryRepository = factoryRepository;
        //}


        //// GET api/warehouses
        //[HttpGet()]
        //public IActionResult GetWarehouses()
        //{
        //    var warehouses = _factoryRepository.GetWarehouses();
        //    return Ok(warehouses);
        //}

        //// GET api/warehouses/{id}
        //[HttpGet("{warehouseId}")]
        //public IActionResult GetWarehouses(int id)
        //{
        //    var warehouse = _factoryRepository.GetWarehouses(id);
        //    if (warehouse == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(warehouse);
        //}
    }
}
