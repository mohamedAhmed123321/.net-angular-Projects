using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoursesProject.Migrations
{
    /// <inheritdoc />
    public partial class addTbPermessions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbforms",
                columns: table => new
                {
                    FormId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControllerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbforms", x => x.FormId);
                });

            migrationBuilder.CreateTable(
                name: "tbpermessions",
                columns: table => new
                {
                    PermessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermessionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbpermessions", x => x.PermessionId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbforms");

            migrationBuilder.DropTable(
                name: "tbpermessions");
        }
    }
}
