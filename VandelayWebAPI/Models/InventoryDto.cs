namespace VandelayWebAPI.Models
{
    public class InventoryDto
    {
        public int ItemId { get; set; }
        public int ItemSKU { get; set; }
        public string ItemQuantity { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int WarehouseId { get; set; }
    }
}
