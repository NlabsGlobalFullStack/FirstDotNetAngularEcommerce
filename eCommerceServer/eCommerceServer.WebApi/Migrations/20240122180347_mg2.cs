using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceServer.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mg2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6a68e681-0044-4419-a8b1-a91575c242c0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7bb58352-81e4-4b88-bb62-ef75f563c038"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c2169225-d2af-454c-a493-844629f95cff"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d4b05ba1-8ba0-4048-96cb-251d1a3279f9"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AppUserId", "CoverImageUrl", "CreatedDate", "Description", "Keywords", "Name", "Price", "SellerId", "Slug" },
                values: new object[,]
                {
                    { new Guid("0f33b500-2d68-4ce5-b3c1-bde4ea36f2b7"), null, "banana.png", new DateTime(2024, 1, 22, 21, 3, 46, 551, DateTimeKind.Local).AddTicks(8403), "", "", "Banana", 50m, new Guid("00000000-0000-0000-0000-000000000000"), "banana" },
                    { new Guid("3e962929-0b1f-411f-be27-926e58910e99"), null, "apple.png", new DateTime(2024, 1, 22, 21, 3, 46, 551, DateTimeKind.Local).AddTicks(8376), "", "", "Apple", 20m, new Guid("00000000-0000-0000-0000-000000000000"), "apple" },
                    { new Guid("4831b18b-17e9-498b-af12-b1fbd2cbbffd"), null, "pear.png", new DateTime(2024, 1, 22, 21, 3, 46, 551, DateTimeKind.Local).AddTicks(8397), "", "", "Pear", 30m, new Guid("00000000-0000-0000-0000-000000000000"), "pear" },
                    { new Guid("593bbb31-b6f1-4a28-84af-4ebc353b7ba1"), null, "watermelon.png", new DateTime(2024, 1, 22, 21, 3, 46, 551, DateTimeKind.Local).AddTicks(8400), "", "", "Watermelon", 120m, new Guid("00000000-0000-0000-0000-000000000000"), "watermelon" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0f33b500-2d68-4ce5-b3c1-bde4ea36f2b7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3e962929-0b1f-411f-be27-926e58910e99"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4831b18b-17e9-498b-af12-b1fbd2cbbffd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("593bbb31-b6f1-4a28-84af-4ebc353b7ba1"));

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AppUserId", "CoverImageUrl", "CreatedDate", "Description", "Keywords", "Name", "Price", "SellerId", "Slug" },
                values: new object[,]
                {
                    { new Guid("6a68e681-0044-4419-a8b1-a91575c242c0"), null, "apple.png", new DateTime(2024, 1, 21, 20, 12, 32, 211, DateTimeKind.Local).AddTicks(1585), "", "", "Apple", 20m, new Guid("00000000-0000-0000-0000-000000000000"), "apple" },
                    { new Guid("7bb58352-81e4-4b88-bb62-ef75f563c038"), null, "pear.png", new DateTime(2024, 1, 21, 20, 12, 32, 211, DateTimeKind.Local).AddTicks(1620), "", "", "Pear", 30m, new Guid("00000000-0000-0000-0000-000000000000"), "pear" },
                    { new Guid("c2169225-d2af-454c-a493-844629f95cff"), null, "watermelon.png", new DateTime(2024, 1, 21, 20, 12, 32, 211, DateTimeKind.Local).AddTicks(1624), "", "", "Watermelon", 120m, new Guid("00000000-0000-0000-0000-000000000000"), "watermelon" },
                    { new Guid("d4b05ba1-8ba0-4048-96cb-251d1a3279f9"), null, "banana.png", new DateTime(2024, 1, 21, 20, 12, 32, 211, DateTimeKind.Local).AddTicks(1628), "", "", "Banana", 50m, new Guid("00000000-0000-0000-0000-000000000000"), "banana" }
                });
        }
    }
}
