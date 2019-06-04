using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VandelayWebAPI.Entities
{
    public class Inventory
    {

        [Key]
        public int ItemId { get; set; }
        [Required]
        public int ItemSKU { get; set; }
        [Required]
        public string ItemQuantity { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public string ItemDescription { get; set; }

        [DefaultValue(false)]
        public bool ItemDelete { get; set; }

        [ForeignKey("WarehouseId")]
        public Warehouse Warehouse { get; set; }
        public int WarehouseId { get; set; }
    }
}
