using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaFaire.Migrations
{
    public partial class secand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "uploads",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UploadDate",
                table: "uploads",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_uploads_UserID",
                table: "uploads",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_uploads_AspNetUsers_UserID",
                table: "uploads",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_uploads_AspNetUsers_UserID",
                table: "uploads");

            migrationBuilder.DropIndex(
                name: "IX_uploads_UserID",
                table: "uploads");

            migrationBuilder.DropColumn(
                name: "UploadDate",
                table: "uploads");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "uploads",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
