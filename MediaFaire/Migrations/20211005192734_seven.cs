using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaFaire.Migrations
{
    public partial class seven : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacts_AspNetUsers_UserId1",
                table: "contacts");

            migrationBuilder.DropIndex(
                name: "IX_contacts_UserId1",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "contacts");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "contacts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_UserId",
                table: "contacts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_AspNetUsers_UserId",
                table: "contacts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacts_AspNetUsers_UserId",
                table: "contacts");

            migrationBuilder.DropIndex(
                name: "IX_contacts_UserId",
                table: "contacts");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "contacts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "contacts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_contacts_UserId1",
                table: "contacts",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_AspNetUsers_UserId1",
                table: "contacts",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
