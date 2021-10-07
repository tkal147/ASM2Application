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
        public DbSet<Trainer> Trainer { get; set; }
        public DbSet<Trainee> Trainee { get; set; }
        public DbSet<TrainingStaff> TrainingStaff { get; set; }
        public DbSet<Admin> Admin { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) // override DbContext's
        {
            modelBuilder.Entity<Course>()
                        .ToTable("Course"); //table name in db

            modelBuilder.Entity<Course>()
                        .HasKey<int>(b => b.Id);  //setup PK

            modelBuilder.Entity<Admin>()
                        .ToTable("Admin"); //table name in db

            modelBuilder.Entity<Admin>()
                        .HasKey<int>(b => b.Id);  //setup PK

            modelBuilder.Entity<TrainingStaff>()
                        .ToTable("TrainingStaff"); //table name in db

            modelBuilder.Entity<TrainingStaff>()
                        .HasKey<int>(b => b.Id);  //setup PK

            modelBuilder.Entity<Trainee>()
                        .ToTable("Trainee"); //table name in db

            modelBuilder.Entity<Trainee>()
                        .HasKey<int>(b => b.Id);  //setup PK

            modelBuilder.Entity<Trainer>()
                        .ToTable("Trainer"); //table name in db

            modelBuilder.Entity<Trainer>()
                        .HasKey<int>(b => b.Id);  //setup PK

            modelBuilder.Entity<Categories>()
                        .ToTable("Categories"); //table name in db

            modelBuilder.Entity<Categories>()
                        .HasKey<int>(b => b.Id);  //setup PK
        }
    }
}