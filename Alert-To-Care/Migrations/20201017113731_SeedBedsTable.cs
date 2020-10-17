using Microsoft.EntityFrameworkCore.Migrations;

namespace Alert_To_Care.Migrations
{
    public partial class SeedBedsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: "3");

            migrationBuilder.InsertData(
                table: "Beds",
                columns: new[] { "BedId", "BedStatus", "IcuId", "PatientId" },
                values: new object[] { "20", true, "34", "2" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "Address", "BedId", "ContactNo", "Email", "PatientAge", "PatientName" },
                values: new object[] { "4", "fgd street, swe city", "42", 98432198, "fdw@adf.com", 38, "Sonam" });

            migrationBuilder.InsertData(
                table: "Vitals",
                columns: new[] { "PatientId", "Bpm", "PatientBedId", "RespRate", "Spo2" },
                values: new object[] { "2", 60f, "20", 70f, 55f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "BedId",
                keyValue: "20");

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Vitals",
                keyColumn: "PatientId",
                keyValue: "2");

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "Address", "BedId", "ContactNo", "Email", "PatientAge", "PatientName" },
                values: new object[] { "3", "abc street, swe city", "32", 987655398, "123@abc.com", 38, "Roopali" });
        }
    }
}
