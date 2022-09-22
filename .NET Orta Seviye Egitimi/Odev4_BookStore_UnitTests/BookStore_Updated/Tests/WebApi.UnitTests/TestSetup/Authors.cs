using WebApi.DbOperations;
using WebApi.Entities;

namespace TestSetup
{
     public static class Authors
     {
        //BookStoreDbContext uzerinden erisilebilecek bir extension metot yaratildi("this" keyword'unu parametre olarak bu objenin basinda kullanarak);
        public static void AddAuthors(this BookStoreDbContext context)
        {
            context.Authors.AddRange(
                new Author{Ad = "Victor", Soyad = "Dunkin", DogumTarihi = new DateTime(1980,06,20), BookId = 1},
                new Author{Ad = "Jeniffer", Soyad = "Hemingway", DogumTarihi = new DateTime(1994,08,19), BookId = 2},
                new Author{Ad = "Burak", Soyad = "Duzgun", DogumTarihi = new DateTime(1988,03,12),BookId=0} //Book Id 0 olarak(default)da verilebilir,yazarin guncel kitabi yoksa.
            );
        }
      }
}