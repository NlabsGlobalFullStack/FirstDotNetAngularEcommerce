using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eCommerceServer.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class productsAddedtoDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CoverImageUrl", "CreatedDate", "Description", "Name", "Price", "Slug", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("3a518234-daff-41bf-94a1-a444af941db5"), "watermelon.png", new DateTime(2023, 12, 30, 20, 22, 31, 641, DateTimeKind.Local).AddTicks(1461), "", "Karpuz", 120m, "", null },
                    { new Guid("96b6068c-0cdc-42b0-adc5-d1b5bdd78533"), "apple.png", new DateTime(2023, 12, 30, 20, 22, 31, 641, DateTimeKind.Local).AddTicks(1386), "", "Elma", 20m, "", null },
                    { new Guid("cb28af49-5fae-4794-9210-f1925dcd63f9"), "banana.png", new DateTime(2023, 12, 30, 20, 22, 31, 641, DateTimeKind.Local).AddTicks(1464), "", "Muz", 50m, "", null },
                    { new Guid("eec3dabc-d837-4636-8c50-004ddcb2db8d"), "pear.png", new DateTime(2023, 12, 30, 20, 22, 31, 641, DateTimeKind.Local).AddTicks(1408), "", "Armut", 30m, "", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3a518234-daff-41bf-94a1-a444af941db5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("96b6068c-0cdc-42b0-adc5-d1b5bdd78533"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cb28af49-5fae-4794-9210-f1925dcd63f9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("eec3dabc-d837-4636-8c50-004ddcb2db8d"));
        }
    }
}
