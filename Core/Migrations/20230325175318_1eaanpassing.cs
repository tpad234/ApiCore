using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class _1eaanpassing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_gebruikers_EigenaarId",
                table: "items");

            migrationBuilder.RenameColumn(
                name: "EigenaarId",
                table: "items",
                newName: "EigenaarID");

            migrationBuilder.RenameIndex(
                name: "IX_items_EigenaarId",
                table: "items",
                newName: "IX_items_EigenaarID");

            migrationBuilder.AddForeignKey(
                name: "FK_items_gebruikers_EigenaarID",
                table: "items",
                column: "EigenaarID",
                principalTable: "gebruikers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_gebruikers_EigenaarID",
                table: "items");

            migrationBuilder.RenameColumn(
                name: "EigenaarID",
                table: "items",
                newName: "EigenaarId");

            migrationBuilder.RenameIndex(
                name: "IX_items_EigenaarID",
                table: "items",
                newName: "IX_items_EigenaarId");

            migrationBuilder.AddForeignKey(
                name: "FK_items_gebruikers_EigenaarId",
                table: "items",
                column: "EigenaarId",
                principalTable: "gebruikers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
