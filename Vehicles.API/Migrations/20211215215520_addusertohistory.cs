using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vehicles.API.Migrations
{
    public partial class addusertohistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Histories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_UserId",
                table: "Histories",
                column: "UserId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Histories_AspNetUsers_UserId",
            //    table: "Histories",
            //    column: "UserId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Histories_AspNetUsers_UserId",
            //    table: "Histories");

            migrationBuilder.DropIndex(
                name: "IX_Histories_UserId",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Histories");
        }
    }
}
