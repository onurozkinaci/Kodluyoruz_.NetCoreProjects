using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DbOperations
{
   public interface IBookStoreDbContext
   {
    //**UT(Unit Test) kapsaminda);
    //Controller uzerinde BookStoreDbContext'i cagirmak yerine, bagimliligi ortadan kaldirmak icin
    //bu interface tanimlandi ve BookStoreDbContext'te verilmis olan DbSet entityleri ve SaveChanges metodu
    //bu interface uzerinde tanimlandi;
       DbSet<Book>Books{get;set;}
       DbSet<Genre>Genres{get;set;}
       DbSet<Author>Authors{get;set;}
       int SaveChanges();
   }
}