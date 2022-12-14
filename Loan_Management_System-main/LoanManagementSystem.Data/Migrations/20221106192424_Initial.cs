using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanManagementSystem.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankDetails",
                columns: table => new
                {
                    BankName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BankAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDetails", x => x.BankName);
                });

            migrationBuilder.CreateTable(
                name: "CustomerInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Custname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phoneno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InterestRate = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    LoanTypeId = table.Column<int>(type: "int", nullable: false),
                    Interest = table.Column<float>(type: "real", nullable: false),
                    CustomerInfoId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Months = table.Column<int>(type: "int", nullable: false),
                    EmiCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emis_CustomerInfos_CustomerInfoId",
                        column: x => x.CustomerInfoId,
                        principalTable: "CustomerInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emis_LoanTypes_LoanTypeId",
                        column: x => x.LoanTypeId,
                        principalTable: "LoanTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplications",
                columns: table => new
                {
                    AppId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanTypeId = table.Column<int>(type: "int", nullable: false),
                    CustomerInfoId = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanApplications", x => x.AppId);
                    table.ForeignKey(
                        name: "FK_LoanApplications_CustomerInfos_CustomerInfoId",
                        column: x => x.CustomerInfoId,
                        principalTable: "CustomerInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplications_LoanTypes_LoanTypeId",
                        column: x => x.LoanTypeId,
                        principalTable: "LoanTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emipayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmiAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaidOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fine = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EmiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emipayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emipayments_Emis_EmiId",
                        column: x => x.EmiId,
                        principalTable: "Emis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CustomerInfos",
                columns: new[] { "Id", "CustAddress", "Custname", "Email", "Pan", "Phoneno" },
                values: new object[,]
                {
                    { 1, "address", "Rohit", "email@email.com", "6846asdf", "9876543210" },
                    { 2, "address", "Ria", "email@email.com", "6846asdf", "9876543210" }
                });

            migrationBuilder.InsertData(
                table: "LoanTypes",
                columns: new[] { "Id", "InterestRate", "LoanTypeName" },
                values: new object[,]
                {
                    { 1, 10f, "Gold_Loan" },
                    { 2, 12f, "Home_Loan" },
                    { 3, 8f, "Personal_Loan" }
                });

            migrationBuilder.InsertData(
                table: "Emis",
                columns: new[] { "Id", "Amount", "CustomerInfoId", "EmiCompleted", "Interest", "LoanTypeId", "Months", "StartDate" },
                values: new object[,]
                {
                    { 1, 1000000, 1, false, 10f, 1, 12, new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 5000000, 2, false, 10f, 1, 24, new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "LoanApplications",
                columns: new[] { "AppId", "Amount", "CustomerInfoId", "LoanTypeId", "status" },
                values: new object[,]
                {
                    { 1, 1000000, 1, 2, 0 },
                    { 2, 100000, 1, 3, 0 }
                });

            migrationBuilder.InsertData(
                table: "Emipayments",
                columns: new[] { "Id", "EmiAmount", "EmiId", "Fine", "IssueDate", "PaidOn" },
                values: new object[] { 1, 83333m, 1, 0m, new DateTime(2022, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Emipayments",
                columns: new[] { "Id", "EmiAmount", "EmiId", "Fine", "IssueDate", "PaidOn" },
                values: new object[] { 2, 83333m, 1, 0m, new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Emipayments",
                columns: new[] { "Id", "EmiAmount", "EmiId", "Fine", "IssueDate", "PaidOn" },
                values: new object[] { 3, 208333m, 2, 0m, new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Emipayments_EmiId",
                table: "Emipayments",
                column: "EmiId");

            migrationBuilder.CreateIndex(
                name: "IX_Emis_CustomerInfoId",
                table: "Emis",
                column: "CustomerInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Emis_LoanTypeId",
                table: "Emis",
                column: "LoanTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_CustomerInfoId",
                table: "LoanApplications",
                column: "CustomerInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_LoanTypeId",
                table: "LoanApplications",
                column: "LoanTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankDetails");

            migrationBuilder.DropTable(
                name: "Emipayments");

            migrationBuilder.DropTable(
                name: "LoanApplications");

            migrationBuilder.DropTable(
                name: "Emis");

            migrationBuilder.DropTable(
                name: "CustomerInfos");

            migrationBuilder.DropTable(
                name: "LoanTypes");
        }
    }
}
