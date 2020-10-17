using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Alert_To_Care.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Alert_To_Care.Repository
{
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options)
        { }
        public DbSet<PatientDataModel> Patients { get; set; }
        public DbSet<BedDataModel> Beds { get; set; }
        public DbSet<IcuDataModel> Icu { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientDataModel>(b =>
            {
                b.HasData(new
                {
                    PatientId = "1",
                    PatientAge = 30,
                    PatientName = "Sneha",
                    BedId = "12",
                    Address = "1ab street, swe city",
                    ContactNo = 0987653412,
                    Email = "123@abc.com"

                });

                b.OwnsOne(e => e.vitals).HasData(new
                {
                    PatientDataModelPatientId = "1",
                    PatientId = "1",
                    PatientBedId = "12",
                    Bpm = 60f,
                    Spo2 = 90f,
                    RespRate = 42f
                });
            });
            modelBuilder.Entity<PatientDataModel>(b =>
            {
                b.HasData(new
                {
                    PatientId = "2",
                    PatientAge = 42,
                    PatientName = "priya",
                    BedId = "32",
                    Address = "123 street, swe city",
                    ContactNo = 0874652391,
                    Email = "223@aer.com"

                });

                b.OwnsOne(e => e.vitals).HasData(new
                {
                    PatientDataModelPatientId = "2",
                    PatientId = "2",
                    PatientBedId = "32",
                    Bpm = 40f,
                    Spo2 = 82f,
                    RespRate = 57f
                });
            });

            modelBuilder.Entity<BedDataModel>().HasData(
                new BedDataModel
                {
                    BedId = "12",
                    BedStatus = true,
                    PatientId = "1",
                    IcuId = "25a"
                },
                new BedDataModel
                {
                    BedId = "32",
                    BedStatus = true,
                    PatientId = "2",
                    IcuId = "25a"
                },
                new BedDataModel
                {
                    BedId = "40",
                    BedStatus = false,
                    PatientId = "",
                    IcuId = "25a"
                }
                );


        }

    }
 
}
