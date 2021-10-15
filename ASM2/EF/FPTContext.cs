using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ASM2.Models.FPT;

namespace ASM2.EF
{
    public class FPTContext : DbContext
    {
        public FPTContext() : base("BwConnection")
        {

        }
        public DbSet<Course> Course { get; set; }
        public DbSet<Categories> Categories { get; set; }

        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) // override DbContext's
        {
            modelBuilder.Entity<Course>()
                        .ToTable("Course"); //table name in db

            modelBuilder.Entity<Course>()
                        .HasKey<int>(b => b.Id);  //setup PK



            modelBuilder.Entity<Categories>()
                        .ToTable("Categories"); //table name in db

            modelBuilder.Entity<Categories>()
                        .HasKey<int>(b => b.Id);  //setup PK
            modelBuilder.Entity<Person>()
                       .ToTable("Person"); //table name in db

            modelBuilder.Entity<Person>()
                        .HasKey<int>(b => b.Id);  //setup PK
        }
    }
}