using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class pogingaddverzoek4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_verzoeken_VerzoekenId",
                table: "items");

            migrationBuilder.AddForeignKey(
                name: "FK_items_verzoeken_VerzoekenId",
                table: "items",
                column: "VerzoekenId",
                principalTable: "verzoeken",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_verzoeken_VerzoekenId",
                table: "items");

            migrationBuilder.AddForeignKey(
                name: "FK_items_verzoeken_VerzoekenId",
                table: "items",
                column: "VerzoekenId",
                principalTable: "verzoeken",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
