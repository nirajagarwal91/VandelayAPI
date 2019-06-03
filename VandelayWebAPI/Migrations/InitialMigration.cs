using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace VandelayWebAPI.Migrations
{
    public partial class InitialMigration: Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Factories",
                columns: table => new
                {
                    FactoryId = table.Column<int>(nullable: false),
                    FactoryName = table.Column<string>(nullable: false),
                    FactoryDescription = table.Column<string>(maxLength: 100, nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factories", x => x.FactoryId);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    MachineId = table.Column<int>(nullable: false),
                    MachineName = table.Column<string>(maxLength: 50, nullable: false),
                    MachineDescription = table.Column<string>(maxLength: 100, nullable: true),
                    FactoryId = table.Column<Int64>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.MachineId);
                    table.ForeignKey(
                        name: "FK_Machines_Factory_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "FactoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "Address",
            //    columns: table => new
            //    {
            //        BuildingName = table.Column<string>(maxLength: 25, nullable: false),
            //        StreetLine1 = table.Column<string>(maxLength: 50, nullable: false),
            //        StreetLine2 = table.Column<string>(maxLength: 50, nullable: true),
            //        City = table.Column<string>(maxLength: 20, nullable: false),
            //        StateProvince = table.Column<string>(maxLength: 10, nullable: false),
            //        ZipPostalCode = table.Column<string>(maxLength: 10, nullable: false),
            //        Country = table.Column<string>(maxLength: 30, nullable: false),
            //        FactoryId = table.Column<Int64>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.ForeignKey(
            //            name: "FK_Address_Factory_FactoryId",
            //            column: x => x.FactoryId,
            //            principalTable: "Factories",
            //            principalColumn: "FactoryId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    WarehouseId = table.Column<int>(nullable: false),
                    WarehouseName = table.Column<string>(nullable: false),
                    WarehouseDescription = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.WarehouseId);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false),
                    ItemSKU = table.Column<int>(nullable: false),
                    ItemQuantity = table.Column<string>(nullable: false),
                    ItemName = table.Column<string>(nullable: false),
                    ItemDescription = table.Column<string>(nullable: true),
                    ItemDelete = table.Column<bool>(nullable: false),
                    WarehouseId = table.Column<Int64>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemId", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Inventory_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_WarehouseId",
                table: "Inventories",
                column: "WarehouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Machines");
            //migrationBuilder.DropTable(
            //    name: "Address");
            migrationBuilder.DropTable(
                name: "Factories");
            migrationBuilder.DropTable(
                name: "Inventories");
            //migrationBuilder.DropTable(
            //    name: "Address");
            migrationBuilder.DropTable(
                name: "Warehouses");

        }
    }
}
