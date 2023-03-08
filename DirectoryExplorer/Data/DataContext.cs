using DirectoryExplorer.Models;
using Microsoft.EntityFrameworkCore;

namespace DirectoryExplorer.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DirectoryModel>()
                .HasOne(d => d.ParentDirectory)
                .WithMany(d => d.ChildDirectories)
                .HasForeignKey(d => d.ParentDirectoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<DirectoryModel> Directories { get; set; }
    }
}
