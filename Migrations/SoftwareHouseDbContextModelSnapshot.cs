﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoftwareHouseManagement.Models;

namespace SoftwareHouseManagement.Migrations
{
    [DbContext(typeof(SoftwareHouseDbContext))]
    partial class SoftwareHouseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<long>("WorkerId")
                        .HasColumnType("bigint");

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
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("ComputerId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PositionId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ComputerId")
                        .IsUnique()
                        .HasFilter("[ComputerId] IS NOT NULL");

                    b.HasIndex("PositionId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("TeamWorker", b =>
                {
                    b.Property<long>("TeamsId")
                        .HasColumnType("bigint");

                    b.Property<long>("WorkersId")
                        .HasColumnType("bigint");

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
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
