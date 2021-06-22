﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoftwareHouseManagement.Models;

namespace SoftwareHouseManagement.Migrations
{
    [DbContext(typeof(SoftwareHouseDbContext))]
    [Migration("20210622120753_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AccessTeam", b =>
                {
                    b.Property<long>("AccessesId")
                        .HasColumnType("bigint");

                    b.Property<long>("TeamsId")
                        .HasColumnType("bigint");

                    b.HasKey("AccessesId", "TeamsId");

                    b.HasIndex("TeamsId");

                    b.ToTable("AccessTeam");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PositionResponsibilities", b =>
                {
                    b.Property<long>("PositionsId")
                        .HasColumnType("bigint");

                    b.Property<long>("ResponsibilitiesId")
                        .HasColumnType("bigint");

                    b.HasKey("PositionsId", "ResponsibilitiesId");

                    b.HasIndex("ResponsibilitiesId");

                    b.ToTable("PositionResponsibilities");
                });

            modelBuilder.Entity("SoftwareHouseManagement.Models.Entities.Access", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accesses");
                });

            modelBuilder.Entity("SoftwareHouseManagement.Models.Entities.Client", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("SoftwareHouseManagement.Models.Entities.Computer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Computers");
                });

            modelBuilder.Entity("SoftwareHouseManagement.Models.Entities.HoursWorked", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Month")
                        .HasColumnType("datetime2");

                    b.Property<long>("ProjectId")
                        .HasColumnType("bigint");

                    b.Property<long?>("TaskId")
                        .HasColumnType("bigint");

                    b.Property<string>("WorkerId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.HasIndex("WorkerId");

                    b.ToTable("HoursWorked");
                });

            modelBuilder.Entity("SoftwareHouseManagement.Models.Entities.Position", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Wage")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("SoftwareHouseManagement.Models.Entities.Responsibilities", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Responsibilities");
                });

            modelBuilder.Entity("SoftwareHouseManagement.Models.Entities.Task", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AssignedHours")
                        .HasColumnType("bigint");

                    b.Property<long>("ClientId")
                        .HasColumnType("bigint");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("WorkedHours")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("SoftwareHouseManagement.Models.Entities.Team", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MemberCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("TaskId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TaskId")
                        .IsUnique()
                        .HasFilter("[TaskId] IS NOT NULL");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("SoftwareHouseManagement.Models.Entities.Worker", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<long?>("ComputerId")
                        .HasColumnType("bigint");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<long?>("PositionId")
                        .HasColumnType("bigint");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("ComputerId")
                        .IsUnique()
                        .HasFilter("[ComputerId] IS NOT NULL");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("PositionId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("TeamWorker", b =>
                {
                    b.Property<long>("TeamsId")
                        .HasColumnType("bigint");

                    b.Property<string>("WorkersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TeamsId", "WorkersId");

                    b.HasIndex("WorkersId");

                    b.ToTable("TeamWorker");
                });

            modelBuilder.Entity("AccessTeam", b =>
                {
                    b.HasOne("SoftwareHouseManagement.Models.Entities.Access", null)
                        .WithMany()
                        .HasForeignKey("AccessesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftwareHouseManagement.Models.Entities.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SoftwareHouseManagement.Models.Entities.Worker", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SoftwareHouseManagement.Models.Entities.Worker", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftwareHouseManagement.Models.Entities.Worker", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SoftwareHouseManagement.Models.Entities.Worker", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PositionResponsibilities", b =>
                {
                    b.HasOne("SoftwareHouseManagement.Models.Entities.Position", null)
                        .WithMany()
                        .HasForeignKey("PositionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftwareHouseManagement.Models.Entities.Responsibilities", null)
                        .WithMany()
                        .HasForeignKey("ResponsibilitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SoftwareHouseManagement.Models.Entities.HoursWorked", b =>
                {
                    b.HasOne("SoftwareHouseManagement.Models.Entities.Task", "Task")
                        .WithMany("HoursWorked")
                        .HasForeignKey("TaskId");

                    b.HasOne("SoftwareHouseManagement.Models.Entities.Worker", "Worker")
                        .WithMany("HoursWorked")
                        .HasForeignKey("WorkerId");

                    b.Navigation("Task");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("SoftwareHouseManagement.Models.Entities.Task", b =>
                {
                    b.HasOne("SoftwareHouseManagement.Models.Entities.Client", "Client")
                        .WithMany("Tasks")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("SoftwareHouseManagement.Models.Entities.Team", b =>
                {
                    b.HasOne("SoftwareHouseManagement.Models.Entities.Task", "Task")
                        .WithOne("Team")
                        .HasForeignKey("SoftwareHouseManagement.Models.Entities.Team", "TaskId");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("SoftwareHouseManagement.Models.Entities.Worker", b =>
                {
                    b.HasOne("SoftwareHouseManagement.Models.Entities.Computer", "Computer")
                        .WithOne("Worker")
                        .HasForeignKey("SoftwareHouseManagement.Models.Entities.Worker", "ComputerId");

                    b.HasOne("SoftwareHouseManagement.Models.Entities.Position", "Position")
                        .WithMany("Workers")
                        .HasForeignKey("PositionId");

                    b.Navigation("Computer");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("TeamWorker", b =>
                {
                    b.HasOne("SoftwareHouseManagement.Models.Entities.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftwareHouseManagement.Models.Entities.Worker", null)
                        .WithMany()
                        .HasForeignKey("WorkersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SoftwareHouseManagement.Models.Entities.Client", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("SoftwareHouseManagement.Models.Entities.Computer", b =>
                {
                    b.Navigation("Worker");
                });

            modelBuilder.Entity("SoftwareHouseManagement.Models.Entities.Position", b =>
                {
                    b.Navigation("Workers");
                });

            modelBuilder.Entity("SoftwareHouseManagement.Models.Entities.Task", b =>
                {
                    b.Navigation("HoursWorked");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("SoftwareHouseManagement.Models.Entities.Worker", b =>
                {
                    b.Navigation("HoursWorked");
                });
#pragma warning restore 612, 618
        }
    }
}