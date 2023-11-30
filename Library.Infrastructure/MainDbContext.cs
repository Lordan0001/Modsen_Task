using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure
{
    public class MainDbContext: DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Title)
                    .IsRequired();
                entity.Property(e => e.Genre)
                    .IsRequired();
                entity.Property(e => e.Description)
                    .IsRequired();
                entity.Property(e => e.Author)
                    .IsRequired();
                entity.HasIndex(e => e.ISBN).IsUnique();
            });

        }
        public DbSet<Book> Books { get; set; }
    }
}
