using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace iDoctor.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updated_role_seeded_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserType",
                value: 2);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "UserType" },
                values: new object[,]
                {
                    { 6, "RegisterAdmin", 1 },
                    { 7, "GetAllUsers", 1 },
                    { 8, "GetAllDoctors", 1 },
                    { 9, "GetVerifiedDoctors", 3 },
                    { 10, "GetDoctorById", 1 },
                    { 11, "GetDoctorById", 2 },
                    { 12, "GetDoctorById", 3 },
                    { 13, "DeleteDoctor", 1 },
                    { 14, "GetVerifiedDoctors", 1 },
                    { 15, "GetUnVerifiedDoctors", 1 },
                    { 16, "GetAllPatients", 1 },
                    { 17, "GetPatientById", 1 },
                    { 18, "GetPatientById", 2 },
                    { 19, "DeletePatient", 1 },
                    { 20, "GetAllAnalyses", 1 },
                    { 21, "GetAllAnalyses", 2 },
                    { 22, "GetAllAnalyses", 3 },
                    { 23, "GetAnalysisById", 1 },
                    { 24, "CreateAnalysis", 1 },
                    { 25, "UpdateAnalysis", 1 },
                    { 26, "DeleteAnalysis", 1 },
                    { 27, "GetAllAppointments", 1 },
                    { 28, "GetDoctorsAllAppointmentsById", 2 },
                    { 29, "GetDoctorsPendingAppointmentsById", 2 },
                    { 30, "GetAppointmentById", 1 },
                    { 31, "GetAppointmentById", 2 },
                    { 32, "DeleteAppointment", 1 },
                    { 33, "AcceptAppointment", 2 },
                    { 34, "DeclineAppointment", 2 },
                    { 35, "GetAllBloodTypes", 3 },
                    { 36, "GetAllBloodTypes", 1 },
                    { 37, "GetBloodTypeById", 1 },
                    { 38, "CreateBloodType", 1 },
                    { 39, "UpdateBloodType", 1 },
                    { 40, "DeleteBloodType", 1 },
                    { 41, "GetAllEducations", 1 },
                    { 42, "GetEducationById", 1 },
                    { 43, "GetEducationsByDoctorId", 2 },
                    { 44, "GetAllGenders", 1 },
                    { 45, "GetAllGenders", 3 },
                    { 46, "GetGenderById", 1 },
                    { 47, "CreateGender", 1 },
                    { 48, "UpdateGender", 1 },
                    { 49, "DeleteGender", 1 },
                    { 50, "GetAllMaritalStatuses", 3 },
                    { 51, "GetAllMaritalStatuses", 1 },
                    { 52, "GetMaritalStatusById", 1 },
                    { 53, "CreateMaritalStatus", 1 },
                    { 54, "UpdateMaritalStatus", 1 },
                    { 55, "DeleteMaritalStatus", 1 },
                    { 56, "GetAllRoles", 1 },
                    { 57, "GetRoleById", 1 },
                    { 58, "CreateRole", 1 },
                    { 59, "UpdateRole", 1 },
                    { 60, "DeleteRole", 1 },
                    { 61, "GetAllSpecialties", 2 },
                    { 62, "GetAllSpecialties", 1 },
                    { 63, "GetSpecialtyById", 1 },
                    { 64, "CreateSpecialty", 1 },
                    { 65, "UpdateSpecialty", 1 },
                    { 66, "DeleteSpecialty", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserType",
                value: 3);
        }
    }
}
