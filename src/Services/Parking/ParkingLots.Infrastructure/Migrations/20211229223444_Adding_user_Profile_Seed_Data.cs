using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingLots.Infrastructure.Migrations
{
    public partial class Adding_user_Profile_Seed_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProfilePermissions",
                keyColumns: new[] { "ProfileId", "PermissionId" },
                keyValues: new object[] { new Guid("b6855d79-4563-49d4-ab7b-b103c4626a5c"), new Guid("9a51bd24-0778-4db3-bd09-dfb5929227cd") },
                column: "Id",
                value: new Guid("f91e638c-74d7-4666-894b-49359e56e8bc"));

            migrationBuilder.UpdateData(
                table: "ProfilePermissions",
                keyColumns: new[] { "ProfileId", "PermissionId" },
                keyValues: new object[] { new Guid("b6855d79-4563-49d4-ab7b-b103c4626a5c"), new Guid("b6855d79-4563-49d4-ab7b-b103c4626a5c") },
                column: "Id",
                value: new Guid("39891b1e-aeaf-4dcc-94b4-b489e02911e1"));

            migrationBuilder.UpdateData(
                table: "ProfilePermissions",
                keyColumns: new[] { "ProfileId", "PermissionId" },
                keyValues: new object[] { new Guid("b6855d79-4563-49d4-ab7b-b103c4626a5c"), new Guid("b970bb7d-422e-4354-8e1c-c40b111dec51") },
                column: "Id",
                value: new Guid("18e5fdeb-b695-412e-aa27-2754b1b3f034"));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("28046bd6-c5ee-4575-96f4-5e236f426ead"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 22, 34, 44, 43, DateTimeKind.Utc).AddTicks(5190), new DateTime(2021, 12, 29, 22, 34, 44, 43, DateTimeKind.Utc).AddTicks(5190) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("28046fe6-b984-4c80-b1d2-8c3920973210"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 22, 34, 44, 43, DateTimeKind.Utc).AddTicks(5190), new DateTime(2021, 12, 29, 22, 34, 44, 43, DateTimeKind.Utc).AddTicks(5190) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("9a51bd24-0778-4db3-bd09-dfb5929227cd"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 22, 34, 44, 43, DateTimeKind.Utc).AddTicks(5180), new DateTime(2021, 12, 29, 22, 34, 44, 43, DateTimeKind.Utc).AddTicks(5180) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("b6855d79-4563-49d4-ab7b-b103c4626a5c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 22, 34, 44, 43, DateTimeKind.Utc).AddTicks(4720), new DateTime(2021, 12, 29, 22, 34, 44, 43, DateTimeKind.Utc).AddTicks(4720) });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "ApplicationUserId", "ProfileId" },
                values: new object[] { new Guid("53599686-8a85-4c66-acc8-2c7f5bddfe47"), new Guid("0468ce24-cf5a-46a2-9b4d-5fb2fdf8e307"), new Guid("b6855d79-4563-49d4-ab7b-b103c4626a5c") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: new Guid("53599686-8a85-4c66-acc8-2c7f5bddfe47"));

            migrationBuilder.UpdateData(
                table: "ProfilePermissions",
                keyColumns: new[] { "ProfileId", "PermissionId" },
                keyValues: new object[] { new Guid("b6855d79-4563-49d4-ab7b-b103c4626a5c"), new Guid("9a51bd24-0778-4db3-bd09-dfb5929227cd") },
                column: "Id",
                value: new Guid("bb999820-351c-4ec4-b5d5-615858f994d2"));

            migrationBuilder.UpdateData(
                table: "ProfilePermissions",
                keyColumns: new[] { "ProfileId", "PermissionId" },
                keyValues: new object[] { new Guid("b6855d79-4563-49d4-ab7b-b103c4626a5c"), new Guid("b6855d79-4563-49d4-ab7b-b103c4626a5c") },
                column: "Id",
                value: new Guid("85750fab-5754-45b4-8625-f691f1b1238d"));

            migrationBuilder.UpdateData(
                table: "ProfilePermissions",
                keyColumns: new[] { "ProfileId", "PermissionId" },
                keyValues: new object[] { new Guid("b6855d79-4563-49d4-ab7b-b103c4626a5c"), new Guid("b970bb7d-422e-4354-8e1c-c40b111dec51") },
                column: "Id",
                value: new Guid("2d6547b9-a9fb-4e35-940a-ae29b1938f15"));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("28046bd6-c5ee-4575-96f4-5e236f426ead"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 17, 28, 19, 712, DateTimeKind.Utc).AddTicks(6940), new DateTime(2021, 12, 29, 17, 28, 19, 712, DateTimeKind.Utc).AddTicks(6940) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("28046fe6-b984-4c80-b1d2-8c3920973210"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 17, 28, 19, 712, DateTimeKind.Utc).AddTicks(6940), new DateTime(2021, 12, 29, 17, 28, 19, 712, DateTimeKind.Utc).AddTicks(6940) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("9a51bd24-0778-4db3-bd09-dfb5929227cd"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 17, 28, 19, 712, DateTimeKind.Utc).AddTicks(6930), new DateTime(2021, 12, 29, 17, 28, 19, 712, DateTimeKind.Utc).AddTicks(6930) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("b6855d79-4563-49d4-ab7b-b103c4626a5c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 17, 28, 19, 712, DateTimeKind.Utc).AddTicks(6160), new DateTime(2021, 12, 29, 17, 28, 19, 712, DateTimeKind.Utc).AddTicks(6160) });
        }
    }
}
