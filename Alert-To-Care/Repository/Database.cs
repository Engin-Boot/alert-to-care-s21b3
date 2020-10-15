using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Alert_To_Care.Models;
using Microsoft.EntityFrameworkCore;

namespace Alert_To_Care.Repository
{
    public class Database:DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options)
        { }
        public DbSet<PatientDataModel> Patients { get; set; }
        public DbSet<BedDataModel> Beds { get; set; }
        public DbSet<IcuDataModel> Icu { get; set; }

    }
}
