using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class pogingaddverzoek2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Verzoeken_gebruikers_OntvangerId",
                table: "Verzoeken");

            migrationBuilder.DropForeignKey(
                name: "FK_Verzoeken_items_ItemId",
                table: "Verzoeken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Verzoeken",
                table: "Verzoeken");

            migrationBuilder.RenameTable(
                name: "Verzoeken",
                newName: "verzoeken");

            migrationBuilder.RenameIndex(
                name: "IX_Verzoeken_OntvangerId",
                table: "verzoeken",
                newName: "IX_verzoeken_OntvangerId");

            migrationBuilder.RenameIndex(
                name: "IX_Verzoeken_ItemId",
                table: "verzoeken",
                newName: "IX_verzoeken_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_verzoeken",
                table: "verzoeken",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_verzoeken_gebruikers_OntvangerId",
                table: "verzoeken",
                column: "OntvangerId",
                principalTable: "gebruikers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_verzoeken_items_ItemId",
                table: "verzoeken",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_verzoeken_gebruikers_OntvangerId",
                table: "verzoeken");

            migrationBuilder.DropForeignKey(
                name: "FK_verzoeken_items_ItemId",
                table: "verzoeken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_verzoeken",
                table: "verzoeken");

            migrationBuilder.RenameTable(
                name: "verzoeken",
                newName: "Verzoeken");

            migrationBuilder.RenameIndex(
                name: "IX_verzoeken_OntvangerId",
                table: "Verzoeken",
                newName: "IX_Verzoeken_OntvangerId");

            migrationBuilder.RenameIndex(
                name: "IX_verzoeken_ItemId",
                table: "Verzoeken",
                newName: "IX_Verzoeken_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Verzoeken",
                table: "Verzoeken",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Verzoeken_gebruikers_OntvangerId",
                table: "Verzoeken",
                column: "OntvangerId",
                principalTable: "gebruikers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Verzoeken_items_ItemId",
                table: "Verzoeken",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
