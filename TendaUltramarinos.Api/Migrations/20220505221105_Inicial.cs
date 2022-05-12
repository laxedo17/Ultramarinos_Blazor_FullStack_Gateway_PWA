using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TendaUltramarinos.Api.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CestaItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CestaId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CestaItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cestas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cestas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductoCategorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconoCss = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoCategorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImaxeUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cantidade = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_ProductoCategorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "ProductoCategorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cestas",
                columns: new[] { "Id", "UsuarioId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductoCategorias",
                columns: new[] { "Id", "IconoCss", "Nome" },
                values: new object[,]
                {
                    { 1, "fas fa-spa", "Beleza" },
                    { 2, "fas fa-couch", "Mobles" },
                    { 3, "fas fa-headphones", "Electronica" },
                    { 4, "fas fa-shoe-prints", "Calzado" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "NomeUsuario" },
                values: new object[,]
                {
                    { 1, "Laurie" },
                    { 2, "Sarah" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Cantidade", "CategoriaId", "Descripcion", "ImaxeUrl", "Nome", "Precio" },
                values: new object[,]
                {
                    { 1, 100, 1, "Un kit fabricado por Glossier, que conten productos para o coidado da pel, do pelo e maquillaxe", "/Imaxes/Beauty/Beauty1.png", "Glossier - Kit de Beleza", 100m },
                    { 2, 45, 1, "Un kit de Curology, que inclue productos para coidar a tua pel", "/Imaxes/Beauty/Beauty2.png", "Curology - Kit Coidado da Pel", 50m },
                    { 3, 30, 1, "Un kit de Curology, que conten productos para o coidado da pel", "/Imaxes/Beauty/Beauty3.png", "Cocooil - Aceite de Coco Organico", 20m },
                    { 4, 60, 1, "Un conxunto de productos de Schwarzkopf, que conten productos para o coidado da pel e do pelo", "/Imaxes/Beauty/Beauty4.png", "Schwarzkopf - Kit de coidado do pelo e da pel", 50m },
                    { 5, 85, 1, "Outro dos kits para coidar a tua pel e o teu pelo, a beleza e o mais importante.", "/Imaxes/Beauty/Beauty5.png", "Kit Coida Peles", 30m },
                    { 6, 120, 3, "Air Pods - auriculares de tapón sen cables ao alcance do oído, e da tua carteira", "/Imaxes/Electronic/Electronics1.png", "Air Pods", 100m },
                    { 7, 200, 3, "Auriculares Golden ao alcance do oído - estes auriculares non son wireless", "/Imaxes/Electronic/Electronics2.png", "Auriculares Golden ao alcance do oído", 40m },
                    { 8, 300, 3, "Auriculares Black - non son wireless", "/Imaxes/Electronic/Electronics3.png", "Auriculares de Diadema Black", 40m },
                    { 9, 20, 3, "Sennheiser Digital Camera - Camara dixital de alta calidade fabricada por Sennheiser - inclue tripode", "/Imaxes/Electronic/Electronic4.png", "Sennheiser Digital Camera con Tripode", 600m },
                    { 10, 15, 3, "Canon Digital Camera - Camara dixital de alta calidade de Canon", "/Imaxes/Electronic/Electronic5.png", "Canon Digital Camera", 500m },
                    { 11, 60, 3, "Gameboy - De Nintendo. A gameboy clásica da tua infancia", "/Imaxes/Electronic/technology6.png", "Nintendo Gameboy", 100m },
                    { 12, 212, 2, "Unha silla moi comoda para mentes inquietas", "/Imaxes/Furniture/Furniture1.png", "Silla de Oficina de Coiro Negro", 50m },
                    { 13, 112, 2, "Silla de oficina con sensibilidade a flor de pel e cor de bonitas plantas", "/Imaxes/Furniture/Furniture2.png", "Silla de Oficina de Coiro Rosa", 50m },
                    { 14, 90, 2, "Unha silla moi comoda para sentarse durante horas", "/Imaxes/Furniture/Furniture3.png", "Silla de Salon", 70m },
                    { 15, 95, 2, "Comodisima e destellante como o cromo, para impactar as tuas visitas", "/Imaxes/Furniture/Furniture4.png", "Silla de Salon Plateada", 120m },
                    { 16, 100, 2, "Lampara de mesa de porcelana branca e azul que ni Porcelanosa a facía tan bonita", "/Imaxes/Furniture/Furniture6.png", "Lampara de Mesa de Porcelana", 15m },
                    { 17, 73, 2, "Unha lampara de mesa que esta ahi, pero pasa desapercibida", "/Imaxes/Furniture/Furniture7.png", "Lampara de Mesa de Oficina", 20m },
                    { 18, 50, 4, "Tenis moi comodos en diferentes tamaños", "/Imaxes/Shoes/Shoes1.png", "Tenis Puma", 100m },
                    { 19, 60, 4, "Unhas moi coloridas zapatillas deportivas disponibles en diferentes tamanhos para ti", "/Imaxes/Shoes/Shoes2.png", "Deportivas coloridas", 150m },
                    { 20, 70, 4, "Tenis Blue Nike Trainers - porque ti o vales", "/Imaxes/Shoes/Shoes3.png", "Tenis Blue Nike", 200m },
                    { 21, 120, 4, "Colorful Hummel Trainers - available in most sizes", "/Imaxes/Shoes/Shoes4.png", "Deportivas Coloridas Hummel", 120m },
                    { 22, 100, 4, "Unhas zapatillas elegantes disponhibles en varios tamanhos", "/Imaxes/Shoes/Shoes5.png", "Deportivas Nike Vermellas", 200m },
                    { 23, 150, 4, "Sandalias para xente chic", "/Imaxes/Shoes/Shoes6.png", "Sandalias Birkenstock", 50m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CestaItems");

            migrationBuilder.DropTable(
                name: "Cestas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "ProductoCategorias");
        }
    }
}
