using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bl.Migrations
{
    /// <inheritdoc />
    public partial class editProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER procedure SpGetHomePageData
(
 @PageNumber int,
 @Count  int
)
AS
BEGIN 
    SET NOCOUNT ON;

    DECLARE @TotalRecords INT;
    DECLARE @TotalPages INT;

    -- Get the total number of records
    SELECT @TotalRecords = COUNT(*)
    FROM VwItems;

    -- Calculate the total number of pages
    SET @TotalPages = CEILING(CAST(@TotalRecords AS FLOAT) / @Count);

    -- Return the paginated data along with the total number of pages as an additional column
    SELECT *, @TotalPages AS TotalPages
    FROM VwItems
    ORDER BY CreatedDate
    OFFSET (@PageNumber - 1) * @Count ROWS
    FETCH NEXT @Count ROWS ONLY;
END
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
