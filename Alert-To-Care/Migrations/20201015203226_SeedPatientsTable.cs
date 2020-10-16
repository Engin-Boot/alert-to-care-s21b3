using Microsoft.EntityFrameworkCore.Migrations;

namespace Alert_To_Care.Migrations
{
    public partial class SeedPatientsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_VitalsDataModel_vitalsPatientId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_vitalsPatientId",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VitalsDataModel",
                table: "VitalsDataModel");

            migrationBuilder.DropColumn(
                name: "vitalsPatientId",
                table: "Patients");

            migrationBuilder.RenameTable(
                name: "VitalsDataModel",
                newName: "Patients1");

            migrationBuilder.AddColumn<int>(
                name: "PatientDataModelPatientId",
                table: "Patients1",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients1",
                table: "Patients1",
                column: "PatientId");

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "Address", "BedId", "ContactNo", "Email", "PatientAge", "PatientName" },
                values: new object[] { 1, "abc stress, swe city", 22, 987655398, "123@abc.com", 22, "Sneha" });

            migrationBuilder.InsertData(
                table: "Patients1",
                columns: new[] { "PatientId", "Bpm", "PatientBedId", "PatientDataModelPatientId", "RespRate", "Spo2" },
                values: new object[] { 1, 70f, 22, 1, 66f, 90f });

            migrationBuilder.CreateIndex(
                name: "IX_Patients1_PatientDataModelPatientId",
                table: "Patients1",
                column: "PatientDataModelPatientId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients1_Patients_PatientDataModelPatientId",
                table: "Patients1",
                column: "PatientDataModelPatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients1_Patients_PatientDataModelPatientId",
                table: "Patients1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients1",
                table: "Patients1");

            migrationBuilder.DropIndex(
                name: "IX_Patients1_PatientDataModelPatientId",
                table: "Patients1");

            migrationBuilder.DeleteData(
                table: "Patients1",
                keyColumn: "PatientId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "PatientDataModelPatientId",
                table: "Patients1");

            migrationBuilder.RenameTable(
                name: "Patients1",
                newName: "VitalsDataModel");

            migrationBuilder.AddColumn<int>(
                name: "vitalsPatientId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VitalsDataModel",
                table: "VitalsDataModel",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_vitalsPatientId",
                table: "Patients",
                column: "vitalsPatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_VitalsDataModel_vitalsPatientId",
                table: "Patients",
                column: "vitalsPatientId",
                principalTable: "VitalsDataModel",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
