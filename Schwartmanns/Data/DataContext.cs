using Microsoft.EntityFrameworkCore;
using Schwartmanns.Models;

namespace Schwartmanns.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Sheet> Sheets { get; set; }
        public DbSet<Circle> Circles { get; set; }
        public DbSet<Line> Lines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User and Project relationship (Zero-to-many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Projects)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            // Client and Project relationship (Zero-to-many)
            modelBuilder.Entity<Client>()
                .HasMany(c => c.Projects)
                .WithOne(p => p.Client)
                .HasForeignKey(p => p.ClientId);

            // Project and Job relationship (One-to-many)
            modelBuilder.Entity<Job>()
                .HasOne(j => j.Project)
                .WithMany(p => p.Jobs)
                .HasForeignKey(j => j.ProjectId);

            // Job and Sheet relationship (One-to-many)
            modelBuilder.Entity<Sheet>()
                .HasOne(s => s.Job)
                .WithMany(j => j.Sheets)
                .HasForeignKey(s => s.JobId);

            // Sheet and Circle relationship (One-to-many)
            modelBuilder.Entity<Circle>()
                .HasOne(c => c.Sheet)
                .WithMany(s => s.Circles)
                .HasForeignKey(c => c.SheetId);

            // Sheet and Line relationship (One-to-many)
            modelBuilder.Entity<Line>()
                .HasOne(l => l.Sheet)
                .WithMany(s => s.Lines)
                .HasForeignKey(l => l.SheetId);
        }
    }
}
