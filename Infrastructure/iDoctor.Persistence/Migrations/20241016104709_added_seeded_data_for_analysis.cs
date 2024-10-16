using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace iDoctor.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class added_seeded_data_for_analysis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Analyses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Qanın Biokimyəvi müayinələri" },
                    { 2, "Sidiyin Biokimyəvi müayinələri" },
                    { 3, "Hemostaz müayinələri" },
                    { 4, "İnfeksiyaların təyini" },
                    { 5, "İmmunoloji müayinələr" },
                    { 6, "Bakterioloji müayinələr" },
                    { 7, "Molekulyar-bioloji müayinələr" },
                    { 8, "Allerqoloji müayinələr" },
                    { 9, "Onkomarker müayinələri" },
                    { 10, "Genetik Testlər" },
                    { 11, "Endokrinoloji müayinələr" },
                    { 12, "Toxuma biopsiyası" },
                    { 13, "Kardioloji testlər" },
                    { 14, "Hormon müayinələri" },
                    { 15, "Autoimmun xəstəliklərin təyini" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Analyses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Analyses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Analyses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Analyses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Analyses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Analyses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Analyses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Analyses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Analyses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Analyses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Analyses",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Analyses",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Analyses",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Analyses",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Analyses",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}
