using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class pogingaddverzoek3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_verzoeken_items_ItemId",
                table: "verzoeken");

            migrationBuilder.DropIndex(
                name: "IX_verzoeken_ItemId",
                table: "verzoeken");

            migrationBuilder.AddColumn<int>(
                name: "VerzoekenId",
                table: "items",
                type: "int",
                nullable: true);

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
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_verzoeken_VerzoekenId",
                table: "items");

            migrationBuilder.DropIndex(
                name: "IX_items_VerzoekenId",
                table: "items");

            migrationBuilder.DropColumn(
                name: "VerzoekenId",
                table: "items");

            migrationBuilder.CreateIndex(
                name: "IX_verzoeken_ItemId",
                table: "verzoeken",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_verzoeken_items_ItemId",
                table: "verzoeken",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
