using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eCommerceServer.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CoverImageUrl", "CreatedDate", "Description", "Name", "Price", "Slug", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("2fe76515-d06a-4b68-b5a3-37b18e0ee3de"), "pear.png", new DateTime(2023, 12, 31, 0, 48, 5, 362, DateTimeKind.Local).AddTicks(179), "", "Armut", 30m, "", null, new Guid("2154e583-04ab-4a9e-a691-44f72925a0e5") },
                    { new Guid("7763f01b-7b37-413f-86dc-323d8c1548c7"), "banana.png", new DateTime(2023, 12, 31, 0, 48, 5, 362, DateTimeKind.Local).AddTicks(187), "", "Muz", 50m, "", null, new Guid("2154e583-04ab-4a9e-a691-44f72925a0e5") },
                    { new Guid("cdbbb2c0-f875-42e2-aa6d-bc7cc6cad86b"), "apple.png", new DateTime(2023, 12, 31, 0, 48, 5, 362, DateTimeKind.Local).AddTicks(108), "", "Elma", 20m, "", null, new Guid("2154e583-04ab-4a9e-a691-44f72925a0e5") },
                    { new Guid("e259f894-ef8f-49bf-b909-f29e3f8f9ad7"), "watermelon.png", new DateTime(2023, 12, 31, 0, 48, 5, 362, DateTimeKind.Local).AddTicks(184), "", "Karpuz", 120m, "", null, new Guid("2154e583-04ab-4a9e-a691-44f72925a0e5") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsAdmin", "LastName", "Password", "UserName" },
                values: new object[] { new Guid("2154e583-04ab-4a9e-a691-44f72925a0e5"), "turkmvc@gmail.com", "Cuma", true, "KÖSE", "String123", "turkmvc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2fe76515-d06a-4b68-b5a3-37b18e0ee3de"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7763f01b-7b37-413f-86dc-323d8c1548c7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cdbbb2c0-f875-42e2-aa6d-bc7cc6cad86b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e259f894-ef8f-49bf-b909-f29e3f8f9ad7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2154e583-04ab-4a9e-a691-44f72925a0e5"));

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
    }
}
