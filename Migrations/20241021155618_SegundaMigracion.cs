using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JT_webBurguer2.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Promos",
                columns: table => new
                {
                    PromosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaPromo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BurguerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promos", x => x.PromosId);
                    table.ForeignKey(
                        name: "FK_Promos_Burguer_BurguerId",
                        column: x => x.BurguerId,
                        principalTable: "Burguer",
                        principalColumn: "BurguerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Promos_BurguerId",
                table: "Promos",
                column: "BurguerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Promos");
        }
    }
}
