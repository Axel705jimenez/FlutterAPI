using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_CRUD.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    idCategoria = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(type: "TEXT", nullable: false),
                    estatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.idCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    idCliente = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(type: "TEXT", nullable: false),
                    apellido = table.Column<string>(type: "TEXT", nullable: false),
                    direccion = table.Column<string>(type: "TEXT", nullable: false),
                    telefono = table.Column<int>(type: "INTEGER", nullable: false),
                    correo = table.Column<string>(type: "TEXT", nullable: false),
                    estatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.idCliente);
                });

            migrationBuilder.CreateTable(
                name: "DetallePedido",
                columns: table => new
                {
                    idDetallePedido = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    precioUnitario = table.Column<decimal>(type: "TEXT", nullable: false),
                    estatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePedido", x => x.idDetallePedido);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    idPedido = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fecha = table.Column<string>(type: "TEXT", nullable: false),
                    direccion = table.Column<string>(type: "TEXT", nullable: false),
                    estatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.idPedido);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    idProducto = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(type: "TEXT", nullable: false),
                    descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    precio = table.Column<decimal>(type: "TEXT", nullable: false),
                    stock = table.Column<int>(type: "INTEGER", nullable: false),
                    estatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.idProducto);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombreUsuario = table.Column<string>(type: "TEXT", nullable: false),
                    contrasena = table.Column<string>(type: "TEXT", nullable: false),
                    correo = table.Column<string>(type: "TEXT", nullable: false),
                    rol = table.Column<string>(type: "TEXT", nullable: false),
                    estatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.idUsuario);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "DetallePedido");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
