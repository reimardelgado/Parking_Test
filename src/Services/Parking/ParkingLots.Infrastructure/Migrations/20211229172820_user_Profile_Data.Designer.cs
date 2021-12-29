﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ParkingLots.Infrastructure;

namespace ParkingLots.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211229172820_user_Profile_Data")]
    partial class user_Profile_Data
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ParkingLots.Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .IsUnicode(false);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("ApplicationUsers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0468ce24-cf5a-46a2-9b4d-5fb2fdf8e307"),
                            Password = "37E4392DAD1AD3D86680A8C6B06EDE92",
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("ParkingLots.Domain.Entities.Parking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Available")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ReservedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("ParkingLots");
                });

            modelBuilder.Entity("ParkingLots.Domain.Entities.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64)
                        .IsUnicode(false);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("ResourceCode")
                        .IsRequired()
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64)
                        .IsUnicode(false);

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b6855d79-4563-49d4-ab7b-b103c4626a5c"),
                            Code = "Parking:Parking:FullAccess",
                            Description = "Acceso total a los parqueaderos",
                            ResourceCode = "PARKING",
                            Type = "global"
                        },
                        new
                        {
                            Id = new Guid("7b3af634-d525-4b07-adfe-c5c1bd7b2a3a"),
                            Code = "Parking:Parking:ReadOnlyAccess",
                            Description = "Acceso de sólo lectura a los parqueaderos",
                            ResourceCode = "PARKING",
                            Type = "global"
                        },
                        new
                        {
                            Id = new Guid("9a51bd24-0778-4db3-bd09-dfb5929227cd"),
                            Code = "Users:Profiles:FullAccess",
                            Description = "Acceso total a los perfiles disponibles",
                            ResourceCode = "USERS",
                            Type = "global"
                        },
                        new
                        {
                            Id = new Guid("c37458ff-ec12-4f2c-b959-1637f37d2caa"),
                            Code = "Users:Profiles:ReadOnlyAccess",
                            Description = "Acceso de sólo lectura a los perfiles disponibles",
                            ResourceCode = "USERS",
                            Type = "global"
                        },
                        new
                        {
                            Id = new Guid("b970bb7d-422e-4354-8e1c-c40b111dec51"),
                            Code = "Users:Managers:FullAccess",
                            Description = "Acceso total a los usuarios",
                            ResourceCode = "USERS",
                            Type = "scoped"
                        },
                        new
                        {
                            Id = new Guid("3f16ee60-60e5-4517-8112-6ee8593f9d5b"),
                            Code = "Users:Managers:ReadOnlyAccess",
                            Description = "Acceso de sólo lectura a los usuarios",
                            ResourceCode = "USERS",
                            Type = "scoped"
                        },
                        new
                        {
                            Id = new Guid("89b8a609-dfd9-4dd7-a124-fb3b0091dde5"),
                            Code = "Users:Managers:ReadEditAccess",
                            Description = "Acceso de lectura y edición a los usuarios",
                            ResourceCode = "USERS",
                            Type = "scoped"
                        },
                        new
                        {
                            Id = new Guid("710282e5-a137-4df2-947a-aa7be3a64196"),
                            Code = "Users:Managers:ResendSignUp",
                            Description = "Capacidad para poder reenviar el correo de registro a los usuarios",
                            ResourceCode = "USERS",
                            Type = "scoped"
                        });
                });

            modelBuilder.Entity("ParkingLots.Domain.Entities.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64)
                        .IsUnicode(false);

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Profiles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b6855d79-4563-49d4-ab7b-b103c4626a5c"),
                            CreatedAt = new DateTime(2021, 12, 29, 17, 28, 19, 712, DateTimeKind.Utc).AddTicks(6160),
                            Description = "Usuario con todos los permisos",
                            Name = "Administrators",
                            UpdatedAt = new DateTime(2021, 12, 29, 17, 28, 19, 712, DateTimeKind.Utc).AddTicks(6160)
                        },
                        new
                        {
                            Id = new Guid("9a51bd24-0778-4db3-bd09-dfb5929227cd"),
                            CreatedAt = new DateTime(2021, 12, 29, 17, 28, 19, 712, DateTimeKind.Utc).AddTicks(6930),
                            Description = "Usuario que tiene puede gestionar los parqueaderos",
                            Name = "Managers",
                            UpdatedAt = new DateTime(2021, 12, 29, 17, 28, 19, 712, DateTimeKind.Utc).AddTicks(6930)
                        },
                        new
                        {
                            Id = new Guid("28046bd6-c5ee-4575-96f4-5e236f426ead"),
                            CreatedAt = new DateTime(2021, 12, 29, 17, 28, 19, 712, DateTimeKind.Utc).AddTicks(6940),
                            Description = "Usuario que sólo reservar parqueaderos",
                            Name = "CommonUsers",
                            UpdatedAt = new DateTime(2021, 12, 29, 17, 28, 19, 712, DateTimeKind.Utc).AddTicks(6940)
                        },
                        new
                        {
                            Id = new Guid("28046fe6-b984-4c80-b1d2-8c3920973210"),
                            CreatedAt = new DateTime(2021, 12, 29, 17, 28, 19, 712, DateTimeKind.Utc).AddTicks(6940),
                            Description = "Usuario que puede ver todo dentro del backend pero sin poder realizar acción alguna",
                            Name = "ReadOnly",
                            UpdatedAt = new DateTime(2021, 12, 29, 17, 28, 19, 712, DateTimeKind.Utc).AddTicks(6940)
                        });
                });

            modelBuilder.Entity("ParkingLots.Domain.Entities.ProfilePermission", b =>
                {
                    b.Property<Guid>("ProfileId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.HasKey("ProfileId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("ProfilePermissions");

                    b.HasData(
                        new
                        {
                            ProfileId = new Guid("b6855d79-4563-49d4-ab7b-b103c4626a5c"),
                            PermissionId = new Guid("b6855d79-4563-49d4-ab7b-b103c4626a5c"),
                            Id = new Guid("85750fab-5754-45b4-8625-f691f1b1238d")
                        },
                        new
                        {
                            ProfileId = new Guid("b6855d79-4563-49d4-ab7b-b103c4626a5c"),
                            PermissionId = new Guid("9a51bd24-0778-4db3-bd09-dfb5929227cd"),
                            Id = new Guid("bb999820-351c-4ec4-b5d5-615858f994d2")
                        },
                        new
                        {
                            ProfileId = new Guid("b6855d79-4563-49d4-ab7b-b103c4626a5c"),
                            PermissionId = new Guid("b970bb7d-422e-4354-8e1c-c40b111dec51"),
                            Id = new Guid("2d6547b9-a9fb-4e35-940a-ae29b1938f15")
                        });
                });

            modelBuilder.Entity("ParkingLots.Domain.Entities.UserGlobalPermission", b =>
                {
                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.HasKey("ApplicationUserId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("UserGlobalPermissions");
                });

            modelBuilder.Entity("ParkingLots.Domain.Entities.UserProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProfileId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ProfileId");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("ParkingLots.Domain.Entities.ProfilePermission", b =>
                {
                    b.HasOne("ParkingLots.Domain.Entities.Permission", "Permission")
                        .WithMany("ProfilePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParkingLots.Domain.Entities.Profile", "Profile")
                        .WithMany("ProfilePermissions")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ParkingLots.Domain.Entities.UserGlobalPermission", b =>
                {
                    b.HasOne("ParkingLots.Domain.Entities.Permission", null)
                        .WithMany("UserGlobalPermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ParkingLots.Domain.Entities.UserProfile", b =>
                {
                    b.HasOne("ParkingLots.Domain.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("UserProfiles")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParkingLots.Domain.Entities.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}