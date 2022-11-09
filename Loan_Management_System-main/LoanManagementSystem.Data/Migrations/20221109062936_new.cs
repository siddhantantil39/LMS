using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanManagementSystem.Data.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BankDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BankAddress", "BankName" },
                values: new object[] { "Test", "Test" });

            migrationBuilder.UpdateData(
                table: "BankDetails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BankAddress", "BankName" },
                values: new object[] { "Test", "Test" });

            migrationBuilder.UpdateData(
                table: "BankDetails",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BankAddress", "BankName" },
                values: new object[] { "Test", "Test" });

            migrationBuilder.UpdateData(
                table: "CustomerInfos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Custname",
                value: "Test1");

            migrationBuilder.UpdateData(
                table: "CustomerInfos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Custname",
                value: "Test2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BankDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BankAddress", "BankName" },
                values: new object[] { "Kondapur", "Kondapur Branch MyBank" });

            migrationBuilder.UpdateData(
                table: "BankDetails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BankAddress", "BankName" },
                values: new object[] { "Madhapur", "Kondapur Branch MyBank" });

            migrationBuilder.UpdateData(
                table: "BankDetails",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BankAddress", "BankName" },
                values: new object[] { "Hitech", "Kondapur Branch MyBank" });

            migrationBuilder.UpdateData(
                table: "CustomerInfos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Custname",
                value: "Rohit");

            migrationBuilder.UpdateData(
                table: "CustomerInfos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Custname",
                value: "Ria");
        }
    }
}
