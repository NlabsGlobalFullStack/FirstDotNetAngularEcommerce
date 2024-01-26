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
                keyValue: new Guid("12963086-b5ca-43fd-9cd6-13e895035932"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5bb42ee2-03d3-441f-b070-802cb12b30ae"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b078ec9f-987a-47fe-80b7-620b2dfb1e7c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b2f12fbd-ba8b-4373-b7a4-0f9c2f484303"));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Sellers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AppUserId", "CoverImageUrl", "CreatedDate", "Description", "Keywords", "Name", "Price", "SellerId", "Slug" },
                values: new object[,]
                {
                    { new Guid("0e8b67ef-3c96-4470-a1f3-bf4014b7ae96"), null, "pear.png", new DateTime(2024, 1, 26, 21, 43, 38, 517, DateTimeKind.Local).AddTicks(2309), "", "", "Pear", 30m, new Guid("abaea843-79e3-4c87-b6d7-baf5131823a5"), "pear" },
                    { new Guid("82045cb2-9e6e-43e6-b1f7-53b4c690ee9d"), null, "apple.png", new DateTime(2024, 1, 26, 21, 43, 38, 517, DateTimeKind.Local).AddTicks(2235), "Güzel Elma", "apple, elma", "Apple", 20m, new Guid("84c4b90e-6903-48be-8c03-f3e681a0d2c7"), "apple" },
                    { new Guid("be07d532-eb52-4149-81cb-1d7ff21300f7"), null, "banana.png", new DateTime(2024, 1, 26, 21, 43, 38, 517, DateTimeKind.Local).AddTicks(2316), "", "", "Banana", 50m, new Guid("f4d52010-ce81-49a0-83f7-6fc4946731d3"), "banana" },
                    { new Guid("f53b96bd-328d-41a4-9b72-7c3ac425c6c6"), null, "watermelon.png", new DateTime(2024, 1, 26, 21, 43, 38, 517, DateTimeKind.Local).AddTicks(2313), "", "", "Watermelon", 120m, new Guid("abd48fe0-270c-4c6c-ae67-f6deb30e35b5"), "watermelon" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0e8b67ef-3c96-4470-a1f3-bf4014b7ae96"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("82045cb2-9e6e-43e6-b1f7-53b4c690ee9d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("be07d532-eb52-4149-81cb-1d7ff21300f7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f53b96bd-328d-41a4-9b72-7c3ac425c6c6"));

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Sellers");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AppUserId", "CoverImageUrl", "CreatedDate", "Description", "Keywords", "Name", "Price", "SellerId", "Slug" },
                values: new object[,]
                {
                    { new Guid("12963086-b5ca-43fd-9cd6-13e895035932"), null, "banana.png", new DateTime(2024, 1, 25, 20, 24, 5, 279, DateTimeKind.Local).AddTicks(6207), "", "", "Banana", 50m, new Guid("26c4426a-f1e7-4bbf-aa31-b2a60f8fc71e"), "banana" },
                    { new Guid("5bb42ee2-03d3-441f-b070-802cb12b30ae"), null, "apple.png", new DateTime(2024, 1, 25, 20, 24, 5, 279, DateTimeKind.Local).AddTicks(6130), "Güzel Elma", "apple, elma", "Apple", 20m, new Guid("399c67cc-83ce-48b6-b208-4c40ec4c59d8"), "apple" },
                    { new Guid("b078ec9f-987a-47fe-80b7-620b2dfb1e7c"), null, "watermelon.png", new DateTime(2024, 1, 25, 20, 24, 5, 279, DateTimeKind.Local).AddTicks(6159), "", "", "Watermelon", 120m, new Guid("a73d2978-70f6-4250-925b-cc9b1d404ccf"), "watermelon" },
                    { new Guid("b2f12fbd-ba8b-4373-b7a4-0f9c2f484303"), null, "pear.png", new DateTime(2024, 1, 25, 20, 24, 5, 279, DateTimeKind.Local).AddTicks(6155), "", "", "Pear", 30m, new Guid("0d9b8878-3cee-4645-b43d-d27f23452f8b"), "pear" }
                });
        }
    }
}
