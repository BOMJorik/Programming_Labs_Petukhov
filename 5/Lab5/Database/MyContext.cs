using Lab5.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab5.Database;

public class MyContext : DbContext
{
    public DbSet<MusicTrack>? Tracks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Tracks.db");
    }
}