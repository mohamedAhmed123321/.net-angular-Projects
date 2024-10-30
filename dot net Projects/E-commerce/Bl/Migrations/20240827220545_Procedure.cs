using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bl.Migrations
{
    /// <inheritdoc />
    public partial class Procedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
Create procedure SpGetHomePageData
(

 @PageNumber int,
 @Count  int

)
as
begin 
select *
from VwItems
 ORDER BY CreatedDate -- Specify the column you want to order by
    OFFSET (@PageNumber - 1) * @Count ROWS
    FETCH NEXT @Count ROWS ONLY;

	  DECLARE @TotalRecords INT;
    DECLARE @TotalPages INT;

    -- Get the total number of records
    SELECT @TotalRecords = COUNT(*)
    FROM VwItems;

    -- Calculate the total number of pages
    SET @TotalPages = CEILING(CAST(@TotalRecords AS FLOAT) / @Count);

    -- Return the total number of pages
    SELECT @TotalPages AS TotalPages;
end");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
