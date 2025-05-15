using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medical_record.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    employeeId = table.Column<int>(type: "int", unicode: false, fixedLength: true, maxLength: 5, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    specialty = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__C134C9C16ED1D79F", x => x.employeeId);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    patientId = table.Column<int>(type: "int", unicode: false, fixedLength: true, maxLength: 5, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CCCD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    birthDate = table.Column<DateOnly>(type: "date", nullable: true),
                    phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    photo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Sex = table.Column<bool>(type: "bit", nullable: false),
                    BloodType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeePayment = table.Column<DateOnly>(type: "date", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Patient__A17005ECE2EF97DC", x => x.patientId);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    reportId = table.Column<int>(type: "int", unicode: false, fixedLength: true, maxLength: 5, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reportType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    generatedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    data = table.Column<string>(type: "text", nullable: true),
                    employeeId = table.Column<int>(type: "int", unicode: false, fixedLength: true, maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Report__1C9B4E2D14E3DF27", x => x.reportId);
                    table.ForeignKey(
                        name: "FK__Report__employee__628FA481",
                        column: x => x.employeeId,
                        principalTable: "Employee",
                        principalColumn: "employeeId");
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    appointmentId = table.Column<int>(type: "int", unicode: false, fixedLength: true, maxLength: 5, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patientId = table.Column<int>(type: "int", unicode: false, fixedLength: true, maxLength: 5, nullable: true),
                    employeeId = table.Column<int>(type: "int", unicode: false, fixedLength: true, maxLength: 5, nullable: true),
                    appointmentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    appointmentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Appointm__D06765FEC75DCD3B", x => x.appointmentId);
                    table.ForeignKey(
                        name: "FK__Appointme__emplo__5BE2A6F2",
                        column: x => x.employeeId,
                        principalTable: "Employee",
                        principalColumn: "employeeId");
                    table.ForeignKey(
                        name: "FK__Appointme__patie__5AEE82B9",
                        column: x => x.patientId,
                        principalTable: "Patient",
                        principalColumn: "patientId");
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecord",
                columns: table => new
                {
                    recordId = table.Column<int>(type: "int", unicode: false, fixedLength: true, maxLength: 5, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patientId = table.Column<int>(type: "int", unicode: false, fixedLength: true, maxLength: 5, nullable: true),
                    admissionDate = table.Column<DateOnly>(type: "date", nullable: true),
                    dischargeDate = table.Column<DateOnly>(type: "date", nullable: true),
                    department = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    room = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    diagnosis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    treatment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MedicalR__D825195E92C503BF", x => x.recordId);
                    table.ForeignKey(
                        name: "FK__MedicalRe__patie__5812160E",
                        column: x => x.patientId,
                        principalTable: "Patient",
                        principalColumn: "patientId");
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    prescriptionId = table.Column<int>(type: "int", unicode: false, fixedLength: true, maxLength: 5, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    recordId = table.Column<int>(type: "int", unicode: false, fixedLength: true, maxLength: 5, nullable: true),
                    employeeId = table.Column<int>(type: "int", unicode: false, fixedLength: true, maxLength: 5, nullable: true),
                    medication = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    dosage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    datePrescribed = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Prescrip__7920FC245F59740F", x => x.prescriptionId);
                    table.ForeignKey(
                        name: "FK__Prescript__emplo__5FB337D6",
                        column: x => x.employeeId,
                        principalTable: "Employee",
                        principalColumn: "employeeId");
                    table.ForeignKey(
                        name: "FK__Prescript__recor__5EBF139D",
                        column: x => x.recordId,
                        principalTable: "MedicalRecord",
                        principalColumn: "recordId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_employeeId",
                table: "Appointment",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_patientId",
                table: "Appointment",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecord_patientId",
                table: "MedicalRecord",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_employeeId",
                table: "Prescription",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_recordId",
                table: "Prescription",
                column: "recordId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_employeeId",
                table: "Report",
                column: "employeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "MedicalRecord");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
