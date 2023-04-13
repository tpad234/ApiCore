using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class pogingaddverzoek6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_verzoeken_VerzoekenId",
                table: "items");

            migrationBuilder.DropIndex(
                name: "IX_items_VerzoekenId",
                table: "items");

            migrationBuilder.CreateIndex(
                name: "IX_verzoeken_ItemId",
                table: "verzoeken",
                column: "ItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_verzoeken_items_ItemId",
                table: "verzoeken",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_verzoeken_items_ItemId",
                table: "verzoeken");

            migrationBuilder.DropIndex(
                name: "IX_verzoeken_ItemId",
                table: "verzoeken");

            migrationBuilder.CreateIndex(
                name: "IX_items_VerzoekenId",
                table: "items",
                column: "VerzoekenId",
                unique: true,
                filter: "[VerzoekenId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_items_verzoeken_VerzoekenId",
                table: "items",
                column: "VerzoekenId",
                principalTable: "verzoeken",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
