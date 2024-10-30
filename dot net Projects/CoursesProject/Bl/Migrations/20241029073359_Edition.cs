using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoursesProject.Migrations
{
    /// <inheritdoc />
    public partial class Edition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TbSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TbSettings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TbSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TbSettings",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TbSettings");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TbSettings");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbSettings");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TbSettings");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TbSettings");

        }
    }
}
