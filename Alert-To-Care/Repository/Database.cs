using System;
using System.Collections.Generic;
using System.Data.Common;
//using System.Data.Entity;
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
        public DbSet<VitalsDataModel> Vitals { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            
             modelBuilder.Entity<PatientDataModel>(b =>
             { b.HasData(new
                 {
                     PatientId = "4",
                     PatientAge = 38,
                     PatientName = "Sonam",
                     BedId = "42",
                     Address = "fgd street, swe city",
                     ContactNo = 098432198,
                     Email = "fdw@adf.com"

                 });
             });
            
            
            modelBuilder.Entity<IcuDataModel>().HasData(
                new IcuDataModel
                {
                    IcuId = "1",
                    TotalNoOfBeds = 3,
                    Layout = "L"  
                },
                 new IcuDataModel
                 {
                     IcuId = "2",
                     TotalNoOfBeds = 1,
                     Layout = "Sq"
                 }
                );
            modelBuilder.Entity<BedDataModel>().HasData(
                new BedDataModel
                {
                    BedId = "20",
                    BedStatus = true,
                    PatientId = "2",
                    IcuId = "34"
                }
                );

            modelBuilder.Entity<VitalsDataModel>().HasData(
                new VitalsDataModel
                {
                    PatientId = "2",
                    PatientBedId = "20",
                    Bpm = 60f,
                    Spo2 = 55f,
                    RespRate = 70f
                }
                );

            ;
        }

    }
 
}
