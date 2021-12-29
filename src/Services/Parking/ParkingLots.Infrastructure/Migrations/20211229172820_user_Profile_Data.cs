using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingLots.Infrastructure.Migrations
{
    public partial class user_Profile_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProfilePermissions",
                keyColumns: new[] { "ProfileId", "PermissionId" },
                keyValues: new object[] { new Guid("b6855d79-4563-49d4-ab7b-b103c4626a5c"), new Guid("9a51bd24-0778-4db3-bd09-dfb5929227cd") },
                column: "Id",
                value: new Guid("e3217fc3-75c7-4ebb-8815-73ddc056c0b4"));

            migrationBuilder.UpdateData(
                table: "ProfilePermissions",
                keyColumns: new[] { "ProfileId", "PermissionId" },
                keyValues: new object[] { new Guid("b6855d79-4563-49d4-ab7b-b103c4626a5c"), new Guid("b6855d79-4563-49d4-ab7b-b103c4626a5c") },
                column: "Id",
                value: new Guid("59e99267-9859-4ac3-bd22-5d4184c0c498"));

            migrationBuilder.UpdateData(
                table: "ProfilePermissions",
                keyColumns: new[] { "ProfileId", "PermissionId" },
                keyValues: new object[] { new Guid("b6855d79-4563-49d4-ab7b-b103c4626a5c"), new Guid("b970bb7d-422e-4354-8e1c-c40b111dec51") },
                column: "Id",
                value: new Guid("432c111e-07e0-4546-ab9b-04f244310217"));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("28046bd6-c5ee-4575-96f4-5e236f426ead"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 13, 58, 0, 459, DateTimeKind.Utc).AddTicks(9190), new DateTime(2021, 12, 29, 13, 58, 0, 459, DateTimeKind.Utc).AddTicks(9190) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("28046fe6-b984-4c80-b1d2-8c3920973210"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 13, 58, 0, 459, DateTimeKind.Utc).AddTicks(9200), new DateTime(2021, 12, 29, 13, 58, 0, 459, DateTimeKind.Utc).AddTicks(9200) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("9a51bd24-0778-4db3-bd09-dfb5929227cd"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 13, 58, 0, 459, DateTimeKind.Utc).AddTicks(9180), new DateTime(2021, 12, 29, 13, 58, 0, 459, DateTimeKind.Utc).AddTicks(9190) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("b6855d79-4563-49d4-ab7b-b103c4626a5c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 29, 13, 58, 0, 459, DateTimeKind.Utc).AddTicks(8770), new DateTime(2021, 12, 29, 13, 58, 0, 459, DateTimeKind.Utc).AddTicks(8770) });
        }
    }
}
