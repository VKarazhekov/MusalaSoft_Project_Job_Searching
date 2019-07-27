using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using JobSearching.Data.Models;

namespace JobSearching.Data
{
    public class JobSearchingDbContext : DbContext
    {
        
        public JobSearchingDbContext(DbContextOptions<JobSearchingDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Employer> Employers { get; set; }
        public DbSet<JobAd> JobAds { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobAd>()
                .HasKey(x => x.Id);

            

            modelBuilder.Entity<JobAd>()
                .HasOne(p => p.Employer)
                .WithMany(b => b.JobAds)
                .HasForeignKey(p => p.EmployerId)
                .HasConstraintName("FK_JobAd_Employer");

            modelBuilder.Entity<Volunteer>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<JobVolunteer>()
                .HasKey(x => new { x.JobAdId, x.VolunteerId });
            modelBuilder.Entity<JobVolunteer>()
                .HasOne(x => x.JobAd)
                .WithMany(m => m.Volunteers)
                .HasForeignKey(x => x.JobAdId);
            modelBuilder.Entity<JobVolunteer>()
                .HasOne(x => x.Volunteer)
                .WithMany(e => e.JobAds)
                .HasForeignKey(x => x.VolunteerId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationData.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
