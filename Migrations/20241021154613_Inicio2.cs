using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JT_webBurguer2.Migrations
{
    /// <inheritdoc />
    public partial class Inicio2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Burguer",
                newName: "BurguerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BurguerId",
                table: "Burguer",
                newName: "Id");
        }
    }
}
