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

            migrationBuilder.AddColumn<string>(
                name: "PatientDataModelPatientId",
                table: "Patients1",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients1",
                table: "Patients1",
                column: "PatientId");

            migrationBuilder.InsertData(
                table: "Beds",
                columns: new[] { "BedId", "BedStatus", "IcuDataModelIcuId", "IcuId", "PatientId" },
                values: new object[,]
                {
                    { "12", true, null, "25a", "1" },
                    { "32", true, null, "25a", "2" },
                    { "40", false, null, "25a", "" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "Address", "BedId", "ContactNo", "Email", "PatientAge", "PatientName" },
                values: new object[,]
                {
                    { "1", "1ab street, swe city", "12", 987653412, "123@abc.com", 30, "Sneha" },
                    { "2", "123 street, swe city", "32", 874652391, "223@aer.com", 42, "priya" }
                });

            migrationBuilder.InsertData(
                table: "Patients1",
                columns: new[] { "PatientId", "Bpm", "PatientBedId", "PatientDataModelPatientId", "RespRate", "Spo2" },
                values: new object[] { "1", 60f, "12", "1", 42f, 90f });

            migrationBuilder.InsertData(
                table: "Patients1",
                columns: new[] { "PatientId", "Bpm", "PatientBedId", "PatientDataModelPatientId", "RespRate", "Spo2" },
                values: new object[] { "2", 40f, "32", "2", 57f, 82f });

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
                table: "Beds",
                keyColumn: "BedId",
                keyValue: "12");

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "BedId",
                keyValue: "32");

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "BedId",
                keyValue: "40");

            migrationBuilder.DeleteData(
                table: "Patients1",
                keyColumn: "PatientId",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Patients1",
                keyColumn: "PatientId",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: "2");

            migrationBuilder.DropColumn(
                name: "PatientDataModelPatientId",
                table: "Patients1");

            migrationBuilder.RenameTable(
                name: "Patients1",
                newName: "VitalsDataModel");

            migrationBuilder.AddColumn<string>(
                name: "vitalsPatientId",
                table: "Patients",
                type: "nvarchar(450)",
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
