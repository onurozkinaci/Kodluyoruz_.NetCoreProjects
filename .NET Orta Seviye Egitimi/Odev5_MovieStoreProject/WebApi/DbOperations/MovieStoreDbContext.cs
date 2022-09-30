using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public class MovieStoreDbContext:DbContext, IMovieStoreDbContext
    {
        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext>options):base(options)
        {}

        public DbSet<Genre> Genres {get; set;}
        public DbSet<Film> Films {get; set;}
        public DbSet<Oyuncu> Oyuncular {get; set;}
        public DbSet<Yonetmen> Yonetmenler {get; set;}
        public DbSet<Customer> Customers {get; set;}
        public DbSet<Siparislerim> Siparisler {get; set;}
        public DbSet<OyuncuFilm> OyuncuFilm {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          modelBuilder.Entity<Siparislerim>().HasKey(sc => new {sc.FilmId, sc.CustomerId});
          modelBuilder.Entity<OyuncuFilm>().HasKey(sc => new {sc.FilmId, sc.OyuncuId});
        }

        public override int SaveChanges()
        { 
          return base.SaveChanges(); //DbContext.SaveChanges() yani, tum yapmak istedigimiz islemler onunla ayni cunku!
        }
    }
}