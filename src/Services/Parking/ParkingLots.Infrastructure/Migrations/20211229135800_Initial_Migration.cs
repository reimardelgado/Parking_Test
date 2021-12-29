using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingLots.Infrastructure.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Password = table.Column<string>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ParkingLots",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Available = table.Column<bool>(nullable: false),
                    ReservedAt = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingLots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(unicode: false, maxLength: 64, nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    ResourceCode = table.Column<string>(unicode: false, maxLength: 64, nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 64, nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserGlobalPermissions",
                columns: table => new
                {
                    ApplicationUserId = table.Column<Guid>(nullable: false),
                    PermissionId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGlobalPermissions", x => new { x.ApplicationUserId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_UserGlobalPermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfilePermissions",
                columns: table => new
                {
                    ProfileId = table.Column<Guid>(nullable: false),
                    PermissionId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilePermissions", x => new { x.ProfileId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_ProfilePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfilePermissions_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ApplicationUserId = table.Column<Guid>(nullable: false),
                    ProfileId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "id", "Password", "UserName" },
                values: new object[] { new Guid("0468ce24-cf5a-46a2-9b4d-5fb2fdf8e307"), "37E4392DAD1AD3D86680A8C6B06EDE92", "admin" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Code", "Description", "ResourceCode", "Type" },
                values: new object[,]
                {
                    { new Guid("b6855d79-4563-49d4-ab7b-b103c4626a5c"), "Parking:Parking:FullAccess", "Acceso total a los parqueaderos", "PARKING", "global" },
                    { new Guid("7b3af634-d525-4b07-adfe-c5c1bd7b2a3a"), "Parking:Parking:ReadOnlyAccess", "Acceso de sólo lectura a los parqueaderos", "PARKING", "global" },
                    { new Guid("9a51bd24-0778-4db3-bd09-dfb5929227cd"), "Users:Profiles:FullAccess", "Acceso total a los perfiles disponibles", "USERS", "global" },
                    { new Guid("c37458ff-ec12-4f2c-b959-1637f37d2caa"), "Users:Profiles:ReadOnlyAccess", "Acceso de sólo lectura a los perfiles disponibles", "USERS", "global" },
                    { new Guid("b970bb7d-422e-4354-8e1c-c40b111dec51"), "Users:Managers:FullAccess", "Acceso total a los usuarios", "USERS", "scoped" },
                    { new Guid("3f16ee60-60e5-4517-8112-6ee8593f9d5b"), "Users:Managers:ReadOnlyAccess", "Acceso de sólo lectura a los usuarios", "USERS", "scoped" },
                    { new Guid("89b8a609-dfd9-4dd7-a124-fb3b0091dde5"), "Users:Managers:ReadEditAccess", "Acceso de lectura y edición a los usuarios", "USERS", "scoped" },
                    { new Guid("710282e5-a137-4df2-947a-aa7be3a64196"), "Users:Managers:ResendSignUp", "Capacidad para poder reenviar el correo de registro a los usuarios", "USERS", "scoped" }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("b6855d79-4563-49d4-ab7b-b103c4626a5c"), new DateTime(2021, 12, 29, 13, 58, 0, 459, DateTimeKind.Utc).AddTicks(8770), null, "Usuario con todos los permisos", "Administrators", new DateTime(2021, 12, 29, 13, 58, 0, 459, DateTimeKind.Utc).AddTicks(8770) },
                    { new Guid("9a51bd24-0778-4db3-bd09-dfb5929227cd"), new DateTime(2021, 12, 29, 13, 58, 0, 459, DateTimeKind.Utc).AddTicks(9180), null, "Usuario que tiene puede gestionar los parqueaderos", "Managers", new DateTime(2021, 12, 29, 13, 58, 0, 459, DateTimeKind.Utc).AddTicks(9190) },
                    { new Guid("28046bd6-c5ee-4575-96f4-5e236f426ead"), new DateTime(2021, 12, 29, 13, 58, 0, 459, DateTimeKind.Utc).AddTicks(9190), null, "Usuario que sólo reservar parqueaderos", "CommonUsers", new DateTime(2021, 12, 29, 13, 58, 0, 459, DateTimeKind.Utc).AddTicks(9190) },
                    { new Guid("28046fe6-b984-4c80-b1d2-8c3920973210"), new DateTime(2021, 12, 29, 13, 58, 0, 459, DateTimeKind.Utc).AddTicks(9200), null, "Usuario que puede ver todo dentro del backend pero sin poder realizar acción alguna", "ReadOnly", new DateTime(2021, 12, 29, 13, 58, 0, 459, DateTimeKind.Utc).AddTicks(9200) }
                });

            migrationBuilder.InsertData(
                table: "ProfilePermissions",
                columns: new[] { "ProfileId", "PermissionId", "Id" },
                values: new object[,]
                {
                    { new Guid("b6855d79-4563-49d4-ab7b-b103c4626a5c"), new Guid("b6855d79-4563-49d4-ab7b-b103c4626a5c"), new Guid("59e99267-9859-4ac3-bd22-5d4184c0c498") },
                    { new Guid("b6855d79-4563-49d4-ab7b-b103c4626a5c"), new Guid("9a51bd24-0778-4db3-bd09-dfb5929227cd"), new Guid("e3217fc3-75c7-4ebb-8815-73ddc056c0b4") },
                    { new Guid("b6855d79-4563-49d4-ab7b-b103c4626a5c"), new Guid("b970bb7d-422e-4354-8e1c-c40b111dec51"), new Guid("432c111e-07e0-4546-ab9b-04f244310217") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_Code",
                table: "Permissions",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePermissions_PermissionId",
                table: "ProfilePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGlobalPermissions_PermissionId",
                table: "UserGlobalPermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_ApplicationUserId",
                table: "UserProfiles",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_ProfileId",
                table: "UserProfiles",
                column: "ProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingLots");

            migrationBuilder.DropTable(
                name: "ProfilePermissions");

            migrationBuilder.DropTable(
                name: "UserGlobalPermissions");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
