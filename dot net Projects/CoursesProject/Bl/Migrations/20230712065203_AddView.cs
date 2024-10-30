using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoursesProject.Migrations
{
    /// <inheritdoc />
    public partial class AddView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create view VwCoustomersCourses
as
SELECT        dbo.TbCustomerCourses.PaymentValue, dbo.TbCustomer.CustomerName, dbo.TbCustomer.CustomerId, dbo.TbCourse.CourseName
FROM            dbo.TbCustomerCourses INNER JOIN
                         dbo.TbCustomer ON dbo.TbCustomerCourses.CustomerId = dbo.TbCustomer.CustomerId INNER JOIN
                         dbo.TbCourse ON dbo.TbCustomerCourses.CourseId = dbo.TbCourse.CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
