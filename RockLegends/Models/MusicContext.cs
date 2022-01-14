using Microsoft.EntityFrameworkCore;
using RockLegends.Models;

namespace RockLegends.Models
{
    public class MusicContext : DbContext
    {
        IWebHostEnvironment _env;

        public MusicContext(DbContextOptions<MusicContext> options, IWebHostEnvironment env) : base(options)
        {
            // Creeer de DB indien noodzakelijk
            //Database.EnsureCreated();

            Database.Migrate();
            _env = env;
        }

        // Een overzicht van alle tabellen in de database

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Album> Albums { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Artist> list = new()
            {
                new Artist { ArtistID = 1, Name = "Rolling Stones", BeginYear = 1962, Photo = LoadImage("RollingStones.jpg") },
                new Artist { ArtistID = 2, Name = "Beatles", BeginYear = 1960, EndYear = 1970, Photo = LoadImage("Beatles.jpg") },
                new Artist { ArtistID = 3, Name = "David Bowie", BeginYear = 1962, EndYear = 2016, Photo = LoadImage("Bowie.jpg") }
            };

            modelBuilder.Entity<Artist>().HasData(list);

            List<Album> albums = new()
            {
                new Album { AlbumID = 1, Title = "Help", Year = 1965, ArtistId = 2 },
                new Album { AlbumID = 2, Title = "Let it bleed", Year = 1971, ArtistId = 1 },
                new Album { AlbumID = 3, Title = "Heroes", Year = 1970, ArtistId = 3 }
            };

            modelBuilder.Entity<Album>().HasData(albums);

        }

        byte[] LoadImage(string filename)
        {
            return File.ReadAllBytes($"./wwwroot/images/{filename}");
        }

    }
}
