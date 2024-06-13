using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_CRUD.Migrations
{
    /// <inheritdoc />
    public partial class AgregarNombreProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nombreProducto",
                table: "DetallePedido",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nombreProducto",
                table: "DetallePedido");
        }
    }
}
