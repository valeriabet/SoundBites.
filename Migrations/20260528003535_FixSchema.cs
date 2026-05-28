using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoundBitesAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaIdCategoria",
                table: "Platos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Platos_CategoriaIdCategoria",
                table: "Platos",
                column: "CategoriaIdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Platos_Categorias_CategoriaIdCategoria",
                table: "Platos",
                column: "CategoriaIdCategoria",
                principalTable: "Categorias",
                principalColumn: "id_categoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Platos_Categorias_CategoriaIdCategoria",
                table: "Platos");

            migrationBuilder.DropIndex(
                name: "IX_Platos_CategoriaIdCategoria",
                table: "Platos");

            migrationBuilder.DropColumn(
                name: "CategoriaIdCategoria",
                table: "Platos");
        }
    }
}
