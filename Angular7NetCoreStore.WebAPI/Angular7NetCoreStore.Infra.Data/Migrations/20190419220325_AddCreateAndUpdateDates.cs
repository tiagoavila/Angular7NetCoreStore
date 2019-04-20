using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular7NetCoreStore.Infra.Data.Migrations
{
    public partial class AddCreateAndUpdateDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3d67fac4-c9fc-4673-9caa-e1197b1f8e7d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("55b0674f-476b-4ee1-bc44-43632743c317"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f74b1ec5-ba80-4fc1-96af-8d233d999db0"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "OrderItems",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "OrderItems",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Customers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Customers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreateDate", "Description", "Image", "Price", "QuantityOnHand", "Title", "UpdateDate" },
                values: new object[] { new Guid("76bf59f0-ffb0-401c-b460-6868d8f924b4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guitarra Ibanex GRG220 Preta", "https://http2.mlstatic.com/guitarra-electrica-ibanez-gio-grg220dex-D_NQ_NP_760329-MLV27359093213_052018-F.jpg", 1200m, 50m, "Guitarra Ibanex GRG220", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreateDate", "Description", "Image", "Price", "QuantityOnHand", "Title", "UpdateDate" },
                values: new object[] { new Guid("5d272276-891c-469a-a653-04f075b2c51a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samsung s9", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRh_iIgH_ErtqFO1tiMpysB3Z5VeJUjaThLCtKkajwXA_V4GXkp", 2000m, 50m, "Celular S9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreateDate", "Description", "Image", "Price", "QuantityOnHand", "Title", "UpdateDate" },
                values: new object[] { new Guid("f2118dcc-60fd-427d-819b-52b2f0ded139"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kindle new generation", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSHmy5pzaQxrs4nzLNXP0Ca-1zkBgzfLCwOMjxmDFDx02FGSzI6", 200m, 50m, "Kindle", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5d272276-891c-469a-a653-04f075b2c51a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("76bf59f0-ffb0-401c-b460-6868d8f924b4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f2118dcc-60fd-427d-819b-52b2f0ded139"));

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Customers");

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
        }
    }
}
