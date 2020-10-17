﻿// <auto-generated />
using Alert_To_Care.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Alert_To_Care.Migrations
{
    [DbContext(typeof(Database))]
    partial class DatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("IcuId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BedId");

                    b.ToTable("Beds");

                    b.HasData(
                        new
                        {
                            BedId = "20",
                            BedStatus = true,
                            IcuId = "34",
                            PatientId = "2"
                        });
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

                    b.HasData(
                        new
                        {
                            IcuId = "1",
                            Layout = "L",
                            TotalNoOfBeds = 3
                        },
                        new
                        {
                            IcuId = "2",
                            Layout = "Sq",
                            TotalNoOfBeds = 1
                        });
                });

            modelBuilder.Entity("Alert_To_Care.Models.PatientDataModel", b =>
                {
                    b.Property<string>("PatientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BedId")
                        .HasColumnType("nvarchar(max)");

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
                            PatientId = "4",
                            Address = "fgd street, swe city",
                            BedId = "42",
                            ContactNo = 98432198,
                            Email = "fdw@adf.com",
                            PatientAge = 38,
                            PatientName = "Sonam"
                        });
                });

            modelBuilder.Entity("Alert_To_Care.Models.VitalsDataModel", b =>
                {
                    b.Property<string>("PatientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("Bpm")
                        .HasColumnType("real");

                    b.Property<string>("PatientBedId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("RespRate")
                        .HasColumnType("real");

                    b.Property<float>("Spo2")
                        .HasColumnType("real");

                    b.HasKey("PatientId");

                    b.ToTable("Vitals");

                    b.HasData(
                        new
                        {
                            PatientId = "2",
                            Bpm = 60f,
                            PatientBedId = "20",
                            RespRate = 70f,
                            Spo2 = 55f
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
