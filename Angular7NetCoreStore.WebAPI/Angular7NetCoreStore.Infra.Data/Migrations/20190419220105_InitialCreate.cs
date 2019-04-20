using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular7NetCoreStore.Infra.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FullName_Name = table.Column<string>(maxLength: 100, nullable: false),
                    FullName_Surname = table.Column<string>(maxLength: 200, nullable: false),
                    Email_Address = table.Column<string>(maxLength: 200, nullable: false),
                    PhoneNumber_AreaCode = table.Column<string>(maxLength: 2, nullable: false),
                    PhoneNumber_Number = table.Column<string>(maxLength: 20, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Address_Street = table.Column<string>(maxLength: 200, nullable: false),
                    Address_Number = table.Column<string>(nullable: true),
                    Address_Complement = table.Column<string>(maxLength: 100, nullable: false),
                    Address_District = table.Column<string>(maxLength: 100, nullable: false),
                    Address_City = table.Column<string>(maxLength: 100, nullable: false),
                    Address_State = table.Column<string>(maxLength: 30, nullable: false),
                    Address_Country = table.Column<string>(maxLength: 100, nullable: false),
                    Address_ZipCode = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Address_Street = table.Column<string>(maxLength: 200, nullable: false),
                    Address_Number = table.Column<string>(nullable: true),
                    Address_Complement = table.Column<string>(maxLength: 100, nullable: false),
                    Address_District = table.Column<string>(maxLength: 100, nullable: false),
                    Address_City = table.Column<string>(maxLength: 100, nullable: false),
                    Address_State = table.Column<string>(maxLength: 30, nullable: false),
                    Address_Country = table.Column<string>(maxLength: 100, nullable: false),
                    Address_ZipCode = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Price", "QuantityOnHand", "Title" },
                values: new object[] { new Guid("3d67fac4-c9fc-4673-9caa-e1197b1f8e7d"), "Guitarra Ibanex GRG220 Preta", "https://http2.mlstatic.com/guitarra-electrica-ibanez-gio-grg220dex-D_NQ_NP_760329-MLV27359093213_052018-F.jpg", 1200m, 50m, "Guitarra Ibanex GRG220" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Price", "QuantityOnHand", "Title" },
                values: new object[] { new Guid("f74b1ec5-ba80-4fc1-96af-8d233d999db0"), "Samsung s9", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRh_iIgH_ErtqFO1tiMpysB3Z5VeJUjaThLCtKkajwXA_V4GXkp", 2000m, 50m, "Celular S9" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Price", "QuantityOnHand", "Title" },
                values: new object[] { new Guid("55b0674f-476b-4ee1-bc44-43632743c317"), "Kindle new generation", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSHmy5pzaQxrs4nzLNXP0Ca-1zkBgzfLCwOMjxmDFDx02FGSzI6", 200m, 50m, "Kindle" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
