using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eCommerceServer.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class updatedProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2447a4b3-6f85-4b2a-9eed-06206d5bc469"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("24fe6972-178d-4ca5-9937-8bfe42c05dbf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4d950e48-8975-412b-813f-b15d92fac39d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bec8a588-ca17-495d-b8e6-58d013ac9d9e"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CoverImageUrl", "CreatedDate", "Description", "Name", "Price", "Slug", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("44e38f2c-35e3-4c07-9f83-0c4259f50c2f"), "watermelon.png", new DateTime(2023, 12, 31, 0, 43, 44, 779, DateTimeKind.Local).AddTicks(9528), "", "Karpuz", 120m, "", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("4ea7df7b-d0cc-4958-87c4-98e2f812e9c7"), "banana.png", new DateTime(2023, 12, 31, 0, 43, 44, 779, DateTimeKind.Local).AddTicks(9531), "", "Muz", 50m, "", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("6cb4e1b0-a328-4eb4-90da-e3d6147a71e9"), "apple.png", new DateTime(2023, 12, 31, 0, 43, 44, 779, DateTimeKind.Local).AddTicks(9446), "", "Elma", 20m, "", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("e60dc537-2f57-424c-8dd6-27861cff47ff"), "pear.png", new DateTime(2023, 12, 31, 0, 43, 44, 779, DateTimeKind.Local).AddTicks(9471), "", "Armut", 30m, "", null, new Guid("00000000-0000-0000-0000-000000000000") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44e38f2c-35e3-4c07-9f83-0c4259f50c2f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4ea7df7b-d0cc-4958-87c4-98e2f812e9c7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6cb4e1b0-a328-4eb4-90da-e3d6147a71e9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e60dc537-2f57-424c-8dd6-27861cff47ff"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CoverImageUrl", "CreatedDate", "Description", "Name", "Price", "Slug", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("2447a4b3-6f85-4b2a-9eed-06206d5bc469"), "watermelon.png", new DateTime(2023, 12, 30, 21, 37, 6, 432, DateTimeKind.Local).AddTicks(7255), "", "Karpuz", 120m, "", null },
                    { new Guid("24fe6972-178d-4ca5-9937-8bfe42c05dbf"), "banana.png", new DateTime(2023, 12, 30, 21, 37, 6, 432, DateTimeKind.Local).AddTicks(7305), "", "Muz", 50m, "", null },
                    { new Guid("4d950e48-8975-412b-813f-b15d92fac39d"), "pear.png", new DateTime(2023, 12, 30, 21, 37, 6, 432, DateTimeKind.Local).AddTicks(7252), "", "Armut", 30m, "", null },
                    { new Guid("bec8a588-ca17-495d-b8e6-58d013ac9d9e"), "apple.png", new DateTime(2023, 12, 30, 21, 37, 6, 432, DateTimeKind.Local).AddTicks(7228), "", "Elma", 20m, "", null }
                });
        }
    }
}
