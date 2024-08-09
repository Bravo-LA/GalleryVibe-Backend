using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ordenCompraActualizacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idUsuario",
                table: "OrdenCompras");

            migrationBuilder.AddColumn<string>(
                name: "Usuario",
                table: "OrdenCompras",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Usuario",
                table: "OrdenCompras");

            migrationBuilder.AddColumn<int>(
                name: "idUsuario",
                table: "OrdenCompras",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
