using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace DataCollectorApp.Models.Core
{
    public class DataCollectorDbContext : DbContext   
    {
        public DataCollectorDbContext() : base("name=DataCollectorString")
        {

        }
        public DbSet<Enquete> Enquetes { get; set; }
    }
}