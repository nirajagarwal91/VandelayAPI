using System.Collections.Generic;

namespace VandelayWebAPI.Entities
{
    public static class WarehouseContextExtension
    {
        public static void SeedDataForWarehouseContext(this WarehouseContext context)
        {
            context.Warehouses.RemoveRange(context.Warehouses);
            context.SaveChanges();

            var warehouses = new List<Warehouse>()
            {
                new Warehouse()
                {
                    WarehouseId = 1001,
                    WarehouseName = "Newark Latex Mfg.",
                    WarehouseDescription =
                        "Key East Coast facility for raw latex material to be processed into final products for the medical industry.",
                    //WarehouseAddress = new Address()
                    //{
                    //    BuildingName = "31 Stone Creek",
                    //    StreetLine1 = "Syracuse Road",
                    //    StreetLine2 = "",
                    //    City = "Columbus",
                    //    StateProvince = "Ohio",
                    //    ZipPostalCode = "46085",
                    //    Country = "United States"
                    //},
                    Inventories = new List<Inventory>()
                    {
                        new Inventory()
                        {
                            ItemId = 101,
                            ItemSKU = 2001,
                            ItemQuantity = "200 LS",
                            ItemName = "Waterproof seal",
                            ItemDescription = "Waterproofing of bathrooms",
                            ItemDelete = false
                        },
                        new Inventory()
                        {
                            ItemId = 102,
                            ItemSKU = 2002,
                            ItemQuantity = "45 BTC",
                            ItemName = "Product A",
                            ItemDescription = "Product description A",
                            ItemDelete = true
                        },
                        new Inventory()
                        {
                            ItemId = 103,
                            ItemSKU = 2003,
                            ItemQuantity = "50 GV",
                            ItemName = "Product B",
                            ItemDescription = "Product B Description",
                            ItemDelete = false
                        },
                        new Inventory()
                        {
                            ItemId = 104,
                            ItemSKU = 2004,
                            ItemQuantity = "200 LCC",
                            ItemName = "Product C",
                            ItemDescription = "Product C Description",
                            ItemDelete = false
                        }
                    }

                }
            };
            context.Warehouses.AddRange(warehouses);
            context.SaveChanges();
        }
    }
}
