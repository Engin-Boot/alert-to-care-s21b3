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
        {

        }
        public DbSet<PatientDataModel> Patients { get; set; }
        public DbSet<BedDataModel> Beds { get; set; }
        public DbSet<IcuDataModel> Icu { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientDataModel>(b =>
            {
                b.HasData(new 
                {
                    PatientId = 1,
                    PatientAge = 22,
                    PatientName = "Sneha",
                    BedId = 22,
                    Address = "abc stress, swe city",
                    ContactNo = 0987655398,
                    Email = "123@abc.com"

                });

                b.OwnsOne(e => e.vitals).HasData(new 
                {
                    PatientDataModelPatientId = 1,
                    PatientId = 1,
                    PatientBedId = 22,
                    Bpm = 70f,
                    Spo2 = 90f,
                    RespRate = 66f
                });
            });
        
        }
        
    }
 
}
