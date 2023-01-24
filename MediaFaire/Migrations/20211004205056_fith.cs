using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaFaire.Migrations
{
    public partial class fith : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UploadCount",
                table: "uploads",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UploadCount",
                table: "uploads");
        }
    }
}
