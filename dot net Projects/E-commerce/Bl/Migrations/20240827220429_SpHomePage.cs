using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bl.Migrations
{
    /// <inheritdoc />
    public partial class SpHomePage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sp_GetHomePageData",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalesPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gpu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HardDisk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemTypeId = table.Column<int>(type: "int", nullable: true),
                    Processor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RamSize = table.Column<int>(type: "int", nullable: true),
                    ScreenReslution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScreenSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OsId = table.Column<int>(type: "int", nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPages = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sp_GetHomePageData", x => x.ItemId);
                });
  
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sp_GetHomePageData");
        }
    }
}
