using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TendaUltramarinos.Api.Migrations
{
    public partial class Milloras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImaxeUrl",
                value: "/Imaxes/Beleza/Beleza1.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImaxeUrl",
                value: "/Imaxes/Beleza/Beleza2.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImaxeUrl",
                value: "/Imaxes/Beleza/Beleza3.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImaxeUrl",
                value: "/Imaxes/Beleza/Beleza4.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImaxeUrl",
                value: "/Imaxes/Beleza/Beleza5.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImaxeUrl",
                value: "/Imaxes/Electronica/Electronica1.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImaxeUrl",
                value: "/Imaxes/Electronica/Electronica2.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImaxeUrl",
                value: "/Imaxes/Electronica/Electronica3.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImaxeUrl",
                value: "/Imaxes/Electronica/Electronica4.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImaxeUrl",
                value: "/Imaxes/Electronica/Electronica5.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImaxeUrl",
                value: "/Imaxes/Electronica/electronica6.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImaxeUrl",
                value: "/Imaxes/Mobles/Mobles1.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImaxeUrl",
                value: "/Imaxes/Mobles/Mobles2.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImaxeUrl",
                value: "/Imaxes/Mobles/Mobles3.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImaxeUrl",
                value: "/Imaxes/Mobles/Mobles4.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImaxeUrl",
                value: "/Imaxes/Mobles/Mobles6.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImaxeUrl",
                value: "/Imaxes/Mobles/Mobles7.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImaxeUrl",
                value: "/Imaxes/Calzado/Calzado1.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 19,
                column: "ImaxeUrl",
                value: "/Imaxes/Calzado/Calzado2.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 20,
                column: "ImaxeUrl",
                value: "/Imaxes/Calzado/Calzado3.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 21,
                column: "ImaxeUrl",
                value: "/Imaxes/Calzado/Calzado4.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 22,
                column: "ImaxeUrl",
                value: "/Imaxes/Calzado/Calzado5.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 23,
                column: "ImaxeUrl",
                value: "/Imaxes/Calzado/Calzado6.png");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "NomeUsuario",
                value: "Sara");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImaxeUrl",
                value: "/Imaxes/Beauty/Beauty1.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImaxeUrl",
                value: "/Imaxes/Beauty/Beauty2.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImaxeUrl",
                value: "/Imaxes/Beauty/Beauty3.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImaxeUrl",
                value: "/Imaxes/Beauty/Beauty4.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImaxeUrl",
                value: "/Imaxes/Beauty/Beauty5.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImaxeUrl",
                value: "/Imaxes/Electronic/Electronics1.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImaxeUrl",
                value: "/Imaxes/Electronic/Electronics2.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImaxeUrl",
                value: "/Imaxes/Electronic/Electronics3.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImaxeUrl",
                value: "/Imaxes/Electronic/Electronic4.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImaxeUrl",
                value: "/Imaxes/Electronic/Electronic5.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImaxeUrl",
                value: "/Imaxes/Electronic/technology6.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImaxeUrl",
                value: "/Imaxes/Furniture/Furniture1.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImaxeUrl",
                value: "/Imaxes/Furniture/Furniture2.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImaxeUrl",
                value: "/Imaxes/Furniture/Furniture3.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImaxeUrl",
                value: "/Imaxes/Furniture/Furniture4.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImaxeUrl",
                value: "/Imaxes/Furniture/Furniture6.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImaxeUrl",
                value: "/Imaxes/Furniture/Furniture7.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImaxeUrl",
                value: "/Imaxes/Shoes/Shoes1.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 19,
                column: "ImaxeUrl",
                value: "/Imaxes/Shoes/Shoes2.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 20,
                column: "ImaxeUrl",
                value: "/Imaxes/Shoes/Shoes3.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 21,
                column: "ImaxeUrl",
                value: "/Imaxes/Shoes/Shoes4.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 22,
                column: "ImaxeUrl",
                value: "/Imaxes/Shoes/Shoes5.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 23,
                column: "ImaxeUrl",
                value: "/Imaxes/Shoes/Shoes6.png");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "NomeUsuario",
                value: "Sarah");
        }
    }
}
