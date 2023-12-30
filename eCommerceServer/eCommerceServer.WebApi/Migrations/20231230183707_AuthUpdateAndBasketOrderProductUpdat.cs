using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eCommerceServer.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AuthUpdateAndBasketOrderProductUpdat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Orders");

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
    }
}
