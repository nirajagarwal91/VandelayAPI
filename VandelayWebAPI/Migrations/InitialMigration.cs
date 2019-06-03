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

            migrationBuilder.CreateIndex(
                name: "IX_Machines_FactoryId",
                table: "Machines",
                column: "FactoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Machines");
            //migrationBuilder.DropTable(
            //    name: "Address");
            migrationBuilder.DropTable(
                name: "Factories");
            
        }
    }
}
