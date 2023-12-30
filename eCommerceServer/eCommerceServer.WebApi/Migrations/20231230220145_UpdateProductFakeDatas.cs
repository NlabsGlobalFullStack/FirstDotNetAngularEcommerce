using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eCommerceServer.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductFakeDatas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("3027f70c-1e4f-4cad-844e-c8b10e4b1d7e"), "pear.png", new DateTime(2023, 12, 31, 1, 1, 44, 701, DateTimeKind.Local).AddTicks(1457), "", "Armut", 30m, "armut", null, new Guid("c8243b08-cce0-4c8b-974c-8d567dd0052a") },
                    { new Guid("70c97b8b-18c1-472c-83c3-c72c61ba61fc"), "watermelon.png", new DateTime(2023, 12, 31, 1, 1, 44, 701, DateTimeKind.Local).AddTicks(1461), "", "Karpuz", 120m, "karpuz", null, new Guid("c8243b08-cce0-4c8b-974c-8d567dd0052a") },
                    { new Guid("95028995-63d8-43c1-82e4-8a61e8fe72fb"), "banana.png", new DateTime(2023, 12, 31, 1, 1, 44, 701, DateTimeKind.Local).AddTicks(1464), "", "Muz", 50m, "muz", null, new Guid("c8243b08-cce0-4c8b-974c-8d567dd0052a") },
                    { new Guid("e1e4c7df-2a3c-4b38-9e1e-e269880315d8"), "apple.png", new DateTime(2023, 12, 31, 1, 1, 44, 701, DateTimeKind.Local).AddTicks(1437), "", "Elma", 20m, "elma", null, new Guid("c8243b08-cce0-4c8b-974c-8d567dd0052a") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsAdmin", "LastName", "Password", "UserName" },
                values: new object[] { new Guid("c8243b08-cce0-4c8b-974c-8d567dd0052a"), "turkmvc@gmail.com", "Cuma", true, "KÖSE", "String123", "turkmvc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3027f70c-1e4f-4cad-844e-c8b10e4b1d7e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("70c97b8b-18c1-472c-83c3-c72c61ba61fc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("95028995-63d8-43c1-82e4-8a61e8fe72fb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e1e4c7df-2a3c-4b38-9e1e-e269880315d8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c8243b08-cce0-4c8b-974c-8d567dd0052a"));

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
    }
}
