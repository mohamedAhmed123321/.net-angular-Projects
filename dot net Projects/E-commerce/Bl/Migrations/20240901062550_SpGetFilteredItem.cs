using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bl.Migrations
{
    /// <inheritdoc />
    public partial class SpGetFilteredItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.CreateTable(
                name: "FilteredItems_Result",
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
                    table.PrimaryKey("PK_FilteredItems_Result", x => x.ItemId);
                });
            migrationBuilder.Sql(@"Create PROCEDURE SpGetFilteredItems
(
    @CategoryName NVARCHAR(100) = NULL,
    @Title NVARCHAR(100) = NULL,
    @RamSize INT = NULL,
    @MinPrice float = NULL,
    @MaxPrice float = NULL,
    @PageNumber INT,
    @Count INT
)
AS
BEGIN
    DECLARE @TotalRecords INT;
    DECLARE @TotalPages INT;

    -- Get the total number of records based on filters
    SELECT @TotalRecords = COUNT(*)
    FROM VwItems
    WHERE 
       (@CategoryName IS NULL OR CategoryName LIKE '%' + @CategoryName + '%')  AND
        (@Title IS NULL OR ItemName LIKE '%' + @Title + '%') AND
        (@RamSize IS NULL OR RamSize = @RamSize) AND
        (@MinPrice IS NULL OR @MaxPrice IS NULL OR (SalesPrice BETWEEN @MinPrice AND @MaxPrice));

    -- Calculate the total number of pages
    SET @TotalPages = CEILING(CAST(@TotalRecords AS FLOAT) / @Count);

    -- Return the paginated data along with the total number of pages as an additional column
    SELECT *, @TotalPages AS TotalPages
    FROM VwItems
    WHERE 
        (@CategoryName IS NULL OR CategoryName LIKE '%' + @CategoryName + '%') AND
        (@Title IS NULL OR ItemName LIKE '%' + @Title + '%') AND
        (@RamSize IS NULL OR RamSize = @RamSize) AND
        (@MinPrice IS NULL OR @MaxPrice IS NULL OR (SalesPrice BETWEEN @MinPrice AND @MaxPrice))
    ORDER BY CreatedDate
    OFFSET (@PageNumber - 1) * @Count ROWS
    FETCH NEXT @Count ROWS ONLY;
END;
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        { 
        }
    }
}
