﻿// <auto-generated />
using Alert_To_Care.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Alert_To_Care.Migrations
{
    [DbContext(typeof(Database))]
    [Migration("20201015203226_SeedPatientsTable")]
    partial class SeedPatientsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Alert_To_Care.Models.BedDataModel", b =>
                {
                    b.Property<string>("BedId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("BedStatus")
                        .HasColumnType("bit");

                    b.Property<string>("IcuDataModelIcuId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IcuId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("BedId");

                    b.HasIndex("IcuDataModelIcuId");

                    b.ToTable("Beds");
                });

            modelBuilder.Entity("Alert_To_Care.Models.IcuDataModel", b =>
                {
                    b.Property<string>("IcuId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Layout")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalNoOfBeds")
                        .HasColumnType("int");

                    b.HasKey("IcuId");

                    b.ToTable("Icu");
                });

            modelBuilder.Entity("Alert_To_Care.Models.PatientDataModel", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BedId")
                        .HasColumnType("int");

                    b.Property<int>("ContactNo")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientAge")
                        .HasColumnType("int");

                    b.Property<string>("PatientName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            PatientId = 1,
                            Address = "abc stress, swe city",
                            BedId = 22,
                            ContactNo = 987655398,
                            Email = "123@abc.com",
                            PatientAge = 22,
                            PatientName = "Sneha"
                        });
                });

            modelBuilder.Entity("Alert_To_Care.Models.BedDataModel", b =>
                {
                    b.HasOne("Alert_To_Care.Models.IcuDataModel", null)
                        .WithMany("IcuBedList")
                        .HasForeignKey("IcuDataModelIcuId");
                });

            modelBuilder.Entity("Alert_To_Care.Models.PatientDataModel", b =>
                {
                    b.OwnsOne("Alert_To_Care.Models.VitalsDataModel", "vitals", b1 =>
                        {
                            b1.Property<int>("PatientId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<float>("Bpm")
                                .HasColumnType("real");

                            b1.Property<int>("PatientBedId")
                                .HasColumnType("int");

                            b1.Property<int>("PatientDataModelPatientId")
                                .HasColumnType("int");

                            b1.Property<float>("RespRate")
                                .HasColumnType("real");

                            b1.Property<float>("Spo2")
                                .HasColumnType("real");

                            b1.HasKey("PatientId");

                            b1.HasIndex("PatientDataModelPatientId")
                                .IsUnique();

                            b1.ToTable("Patients1");

                            b1.WithOwner()
                                .HasForeignKey("PatientDataModelPatientId");

                            b1.HasData(
                                new
                                {
                                    PatientId = 1,
                                    Bpm = 70f,
                                    PatientBedId = 22,
                                    PatientDataModelPatientId = 1,
                                    RespRate = 66f,
                                    Spo2 = 90f
                                });
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
