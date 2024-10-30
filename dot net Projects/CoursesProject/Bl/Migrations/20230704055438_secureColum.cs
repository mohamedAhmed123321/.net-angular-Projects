using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoursesProject.Migrations
{
    /// <inheritdoc />
    public partial class secureColum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TbPaymentMethod",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TbPaymentMethod",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbPaymentMethod",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TbPaymentMethod",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TbPaymentMethod",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TbInstructor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TbInstructor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbInstructor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TbInstructor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TbInstructor",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TbFeatures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TbFeatures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbFeatures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TbFeatures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TbFeatures",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TbCustomerCourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TbCustomerCourses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbCustomerCourses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TbCustomerCourses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TbCustomerCourses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TbCustomer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TbCustomer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbCustomer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TbCustomer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TbCustomer",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TbCourseType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TbCourseType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbCourseType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TbCourseType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TbCourseType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TbCourse",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TbCourse",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbCourse",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TbCourse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TbCourse",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TbPaymentMethod");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TbPaymentMethod");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbPaymentMethod");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TbPaymentMethod");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TbPaymentMethod");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TbInstructor");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TbInstructor");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbInstructor");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TbInstructor");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TbInstructor");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TbFeatures");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TbFeatures");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbFeatures");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TbFeatures");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TbFeatures");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TbCustomerCourses");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TbCustomerCourses");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbCustomerCourses");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TbCustomerCourses");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TbCustomerCourses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TbCustomer");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TbCustomer");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbCustomer");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TbCustomer");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TbCustomer");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TbCourseType");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TbCourseType");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbCourseType");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TbCourseType");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TbCourseType");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TbCourse");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TbCourse");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbCourse");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TbCourse");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TbCourse");
        }
    }
}
