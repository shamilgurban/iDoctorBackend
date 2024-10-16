using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace iDoctor.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class added_gender_bloodtype_martialstatus_seeded_datas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BloodTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "O(I) Rh+" },
                    { 2, "O(I) Rh-" },
                    { 3, "A(II) Rh+" },
                    { 4, "A(II) Rh-" },
                    { 5, "B(III) Rh+" },
                    { 6, "B(III) Rh-" },
                    { 7, "AB(IV) Rh+" },
                    { 8, "AB(IV) Rh-" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Qadın" },
                    { 2, "Kişi" }
                });

            migrationBuilder.InsertData(
                table: "MartialStatuses",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Subay" },
                    { 2, "Evli" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MartialStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MartialStatuses",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
