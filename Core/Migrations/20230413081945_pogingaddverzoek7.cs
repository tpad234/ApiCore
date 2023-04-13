using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class pogingaddverzoek7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_gebruikers_EigenaarId",
                table: "items");

            migrationBuilder.AddForeignKey(
                name: "FK_items_gebruikers_EigenaarId",
                table: "items",
                column: "EigenaarId",
                principalTable: "gebruikers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_gebruikers_EigenaarId",
                table: "items");

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
