using Microsoft.EntityFrameworkCore;
using MyMusicApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicApp.Infrastructure.Database
{
    public class DatabaseContext :DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongRating> SongRatings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Song>().HasOne(x => x.Category).WithMany(d => d.Songs).HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<SongRating>().HasKey(x => new { x.SongId, x.UserId });
        }
    }
}
