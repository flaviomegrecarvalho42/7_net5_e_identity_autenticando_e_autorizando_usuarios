using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosAPI.Migrations
{
    public partial class AddCustonIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "09b9d41f-f8b1-4f2b-8b17-c3286966cee3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "864373bd-2f63-4487-9b4e-e8f827cbb295");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb87804c-a244-46ed-a864-60b96a085a54", "AQAAAAEAACcQAAAAEHETBhiEwERVhwe0JCPrvnfhmdv5O2Ehx+KANThf4a1bCcyA+MDHE2AE12sxez+77g==", "24027b10-d232-47e4-ba82-2de458ace61f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "7ab35d35-aaf0-4348-a997-b10d026c5863");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "f038f8af-b89a-44e1-8063-003f1ddb08e9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8017ad07-91a8-47be-ad3a-771e16e784f4", "AQAAAAEAACcQAAAAEJVauUf/eTdB24yc/Oj1sY4k5DoOp8XakV4cu3UHgzP5l9vfCGyeXh1TM/HDBgKMjw==", "7e25b55e-c84d-46c1-a424-9065b8a242cf" });
        }
    }
}
