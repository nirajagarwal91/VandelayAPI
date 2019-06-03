using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VandelayWebAPI.Entities
{
    public class Warehouse
    {
        [Key]
        public int WarehouseId { get; set; }
        [Required]
        public string WarehouseName { get; set; }
        [Required]
        public string WarehouseDescription { get; set; }

        //[Required]
        //public Address WarehouseAddress { get; set; }

        public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    }
}
