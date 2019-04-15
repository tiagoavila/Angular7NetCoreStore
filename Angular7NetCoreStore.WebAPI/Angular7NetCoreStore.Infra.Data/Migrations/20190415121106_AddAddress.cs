using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular7NetCoreStore.Infra.Data.Migrations
{
    public partial class AddAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("90cac6cb-be67-4aa7-b7b1-20c99dae032d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("12a0652b-2a19-42e0-928c-635413be9211"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ac85d7b6-8844-4bb1-b687-45249929497c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ef4383a1-3721-422b-a90a-8c5f86943e7b"));

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Street = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Number = table.Column<string>(nullable: true),
                    Complement = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    District = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Country = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ZipCode = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BirthDate", "Email", "Name", "PhoneNumber" },
                values: new object[] { new Guid("72e76235-e5ee-4a71-9586-ef5569e23947"), new DateTime(1991, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "tiago.avila09@gmail.com", "Tiago Aparecido de Ávila", "(35)99218-3713" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Price", "QuantityOnHand", "Title" },
                values: new object[,]
                {
                    { new Guid("bcf546ef-2024-4639-a719-2be9a84e55b2"), "Guitarra Ibanex GRG220 Preta", "https://http2.mlstatic.com/guitarra-electrica-ibanez-gio-grg220dex-D_NQ_NP_760329-MLV27359093213_052018-F.jpg", 1200m, 50m, "Guitarra Ibanex GRG220" },
                    { new Guid("48630ee6-88dc-47c6-8bf7-1ed1631f6b1c"), "Samsung s9", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRh_iIgH_ErtqFO1tiMpysB3Z5VeJUjaThLCtKkajwXA_V4GXkp", 2000m, 50m, "Celular S9" },
                    { new Guid("fd1c95c1-4e5c-487c-8c56-cdf320c31d9c"), "Kindle new generation", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSHmy5pzaQxrs4nzLNXP0Ca-1zkBgzfLCwOMjxmDFDx02FGSzI6", 200m, 50m, "Kindle" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("72e76235-e5ee-4a71-9586-ef5569e23947"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("48630ee6-88dc-47c6-8bf7-1ed1631f6b1c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bcf546ef-2024-4639-a719-2be9a84e55b2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fd1c95c1-4e5c-487c-8c56-cdf320c31d9c"));

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
    }
}
