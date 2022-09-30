using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public interface IMovieStoreDbContext
    {
       DbSet<Film>Films {get;set;}
       DbSet<Oyuncu>Oyuncular {get;set;}
       DbSet<Yonetmen>Yonetmenler {get;set;}
       DbSet<Customer>Customers {get;set;}
       DbSet<Genre> Genres {get; set;}
       DbSet<Siparislerim>Siparisler {get;set;}
       DbSet<OyuncuFilm> OyuncuFilm {get; set;}
       int SaveChanges();
    }
}