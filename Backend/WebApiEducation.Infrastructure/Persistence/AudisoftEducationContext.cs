using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiEducation.Domain.Entity;

namespace WebApiEducation.Infrastructure.Persistence
{
    public class AudisoftEducationContext : DbContext
    {
        public AudisoftEducationContext(DbContextOptions<AudisoftEducationContext> options)
             : base(options) { }

        //Entities

        public DbSet<Student> Student { get; set; }
        public DbSet<Note> Note { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<LogWebApi> LogWebApi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AudisoftEducationContext).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Note>()
           .HasKey(sc => new { sc.Id});

            modelBuilder.Entity<Note>()
             .HasOne(n => n.Student)              
             .WithMany(s => s.Note)               
             .HasForeignKey(n => n.idStudent)     
             .OnDelete(DeleteBehavior.Cascade);
         
            
            modelBuilder.Entity<Note>()
             .HasOne(n => n.Teacher)
             .WithMany(s => s.Note)
             .HasForeignKey(n => n.idTeacher)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Teacher>()
           .HasKey(sc => new { sc.Id });

            modelBuilder.Entity<Student>()
           .HasKey(sc => new { sc.Id });

            modelBuilder.Entity<LogWebApi>()
            .HasKey(sc => new { sc.Id });

        }
    }
}
