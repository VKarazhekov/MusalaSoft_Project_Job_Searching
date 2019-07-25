using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using JobSearching.Data.Models;

namespace JobSearching.Data
{
    public class JobSearchingDbContext : DbContext
    {
        public JobSearchingDbContext()
        {

        }
        public JobSearchingDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobAd>()
                .HasKey(x => x.id);

            modelBuilder.Entity<Volunteer>()
                .HasKey(x => x.id);

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
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<JobAd> JobAds { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
    }
}
