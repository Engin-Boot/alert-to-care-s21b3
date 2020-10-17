using Microsoft.EntityFrameworkCore.Migrations;

namespace Alert_To_Care.Migrations
{
    public partial class SeedIcuTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: "1");

            migrationBuilder.InsertData(
                table: "Icu",
                columns: new[] { "IcuId", "Layout", "TotalNoOfBeds" },
                values: new object[] { "1", "L", 3 });

            migrationBuilder.InsertData(
                table: "Icu",
                columns: new[] { "IcuId", "Layout", "TotalNoOfBeds" },
                values: new object[] { "2", "Sq", 1 });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "Address", "BedId", "ContactNo", "Email", "PatientAge", "PatientName" },
                values: new object[] { "3", "abc street, swe city", "32", 987655398, "123@abc.com", 38, "Roopali" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Icu",
                keyColumn: "IcuId",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Icu",
                keyColumn: "IcuId",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: "3");

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "Address", "BedId", "ContactNo", "Email", "PatientAge", "PatientName" },
                values: new object[] { "1", "abc street, swe city", "12", 987655398, "123@abc.com", 22, "Sneha" });
        }
    }
}
