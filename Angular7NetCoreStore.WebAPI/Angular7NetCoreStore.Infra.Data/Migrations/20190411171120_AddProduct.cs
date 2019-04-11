using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular7NetCoreStore.Infra.Data.Migrations
{
    public partial class AddProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("88d86709-0022-4df4-98d0-6450a8b92aeb"));

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false),
                    Image = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    QuantityOnHand = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BirthDate", "Email", "Name", "PhoneNumber" },
                values: new object[] { new Guid("90cac6cb-be67-4aa7-b7b1-20c99dae032d"), new DateTime(1991, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "tiago.avila09@gmail.com", "Tiago Aparecido de Ávila", "(35)99218-3713" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Price", "QuantityOnHand", "Title" },
                values: new object[,]
                {
                    { new Guid("ac85d7b6-8844-4bb1-b687-45249929497c"), "Guitarra Ibanex GRG220 Preta", "https://http2.mlstatic.com/guitarra-electrica-ibanez-gio-grg220dex-D_NQ_NP_760329-MLV27359093213_052018-F.jpg", 1200m, 50m, "Guitarra Ibanex GRG220" },
                    { new Guid("12a0652b-2a19-42e0-928c-635413be9211"), "Samsung s9", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRh_iIgH_ErtqFO1tiMpysB3Z5VeJUjaThLCtKkajwXA_V4GXkp", 2000m, 50m, "Celular S9" },
                    { new Guid("ef4383a1-3721-422b-a90a-8c5f86943e7b"), "Kindle new generation", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSHmy5pzaQxrs4nzLNXP0Ca-1zkBgzfLCwOMjxmDFDx02FGSzI6", 200m, 50m, "Kindle" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("90cac6cb-be67-4aa7-b7b1-20c99dae032d"));

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BirthDate", "Email", "Name", "PhoneNumber" },
                values: new object[] { new Guid("88d86709-0022-4df4-98d0-6450a8b92aeb"), new DateTime(1991, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "tiago.avila09@gmail.com", "Tiago Aparecido de Ávila", "(35)99218-3713" });
        }
    }
}
