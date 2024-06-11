using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class AppContextFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientIdPatients",
                table: "prescriptions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "patient",
                columns: table => new
                {
                    IdPatients = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<string>(type: "nvarchar(max)", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient", x => x.IdPatients);
                });

            migrationBuilder.CreateIndex(
                name: "IX_prescriptions_PatientIdPatients",
                table: "prescriptions",
                column: "PatientIdPatients");

            migrationBuilder.AddForeignKey(
                name: "FK_prescriptions_patient_PatientIdPatients",
                table: "prescriptions",
                column: "PatientIdPatients",
                principalTable: "patient",
                principalColumn: "IdPatients");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_prescriptions_patient_PatientIdPatients",
                table: "prescriptions");

            migrationBuilder.DropTable(
                name: "patient");

            migrationBuilder.DropIndex(
                name: "IX_prescriptions_PatientIdPatients",
                table: "prescriptions");

            migrationBuilder.DropColumn(
                name: "PatientIdPatients",
                table: "prescriptions");
        }
    }
}
