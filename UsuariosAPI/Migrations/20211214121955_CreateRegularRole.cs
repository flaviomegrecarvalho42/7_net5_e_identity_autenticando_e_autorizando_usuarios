using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosAPI.Migrations
{
    public partial class CreateRegularRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "f038f8af-b89a-44e1-8063-003f1ddb08e9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99998, "7ab35d35-aaf0-4348-a997-b10d026c5863", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8017ad07-91a8-47be-ad3a-771e16e784f4", "AQAAAAEAACcQAAAAEJVauUf/eTdB24yc/Oj1sY4k5DoOp8XakV4cu3UHgzP5l9vfCGyeXh1TM/HDBgKMjw==", "7e25b55e-c84d-46c1-a424-9065b8a242cf" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "402f0d81-259d-43ba-b752-f343bcdeec61");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dbcdd6f1-f466-43db-856d-62cb69fbe8f0", "AQAAAAEAACcQAAAAEAvPv5tTLUqybLFhdhNfUsD7jSb115plbnppL7LBd4wZnZNGKGtQo4crIjd6M4k14g==", "e35d10bc-0f1a-4866-9418-350f5ff9f4a6" });
        }
    }
}
