using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medical_record.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PhieuKhamBenhTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhieuKhamBenhs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    MedicalRecordRecordId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuKhamBenhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhieuKhamBenhs_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "employeeId");
                    table.ForeignKey(
                        name: "FK_PhieuKhamBenhs_MedicalRecord_MedicalRecordRecordId",
                        column: x => x.MedicalRecordRecordId,
                        principalTable: "MedicalRecord",
                        principalColumn: "recordId");
                });

            migrationBuilder.CreateTable(
                name: "PhieuKhamBenhDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhieuKhamId = table.Column<int>(type: "int", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhieuKhamBenhId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuKhamBenhDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhieuKhamBenhDetails_PhieuKhamBenhs_PhieuKhamBenhId",
                        column: x => x.PhieuKhamBenhId,
                        principalTable: "PhieuKhamBenhs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhieuKhamBenhDetails_PhieuKhamBenhId",
                table: "PhieuKhamBenhDetails",
                column: "PhieuKhamBenhId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuKhamBenhs_EmployeeId",
                table: "PhieuKhamBenhs",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuKhamBenhs_MedicalRecordRecordId",
                table: "PhieuKhamBenhs",
                column: "MedicalRecordRecordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhieuKhamBenhDetails");

            migrationBuilder.DropTable(
                name: "PhieuKhamBenhs");
        }
    }
}
