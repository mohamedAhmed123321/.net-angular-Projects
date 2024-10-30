using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoursesProject.Migrations
{
    /// <inheritdoc />
    public partial class VwDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create view vwdetails
as
SELECT        dbo.TbCourse.Description, dbo.TbCourse.CourseId, dbo.TbCourse.Price, dbo.TbCourse.ImageName, dbo.TbCourse.instructorId, dbo.TbCourse.BookingPrice, dbo.TbCourse.CourseTypeId, dbo.TbCourse.Video, 
                         dbo.TbCourse.CourseName, dbo.TbCourse.Lectures, dbo.TbCourse.SkillLevel, dbo.TbCourse.Time, dbo.TbCourse.minute, dbo.TbCourse.CreatedBy, dbo.TbCourse.CreatedDate, dbo.TbCourse.CurrentState, 
                         dbo.TbCourse.UpdatedBy, dbo.TbCourse.UpdatedDate, dbo.TbInstructor.InstructorName
FROM            dbo.TbCourse INNER JOIN
                         dbo.TbInstructor ON dbo.TbCourse.instructorId = dbo.TbInstructor.InstructorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
