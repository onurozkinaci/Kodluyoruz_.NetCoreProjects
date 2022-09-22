using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DbOperations;

namespace TestSetup
{
    public class CommonTestFixture
    {
       public BookStoreDbContext Context {get;set;}
       public IMapper Mapper {get;set;}
       public CommonTestFixture()
       {
          var options = new DbContextOptionsBuilder<BookStoreDbContext>().UseInMemoryDatabase(databaseName: "BookstoreTestDb").Options;
          Context = new BookStoreDbContext(options);
          Context.Database.EnsureCreated(); //database'in olusturulup olusturulmadigindan emin olunur.

          //*InMemory db ilk olustugunda Db'nin bos olmamasi, default degerle baslatilmasi icin;
          Context.AddBooks();
          Context.AddGenres();
          Context.AddAuthors();
          Context.SaveChanges(); //en son db'ye eklemeyi tamamlamak-commit basmak icin.
          
          //*Context tanimi yukaridaki gibi bittikten sonra, Mapper config'ini de olasi degisiklikler test'i engellemesin diye WebApi altinda olusturmus oldugumuz MappingProfile'daki map tanimlarini konfigure ederek
          //atiyoruz, calistiriyoruz;
          Mapper = new MapperConfiguration(cfg => {cfg.AddProfile<MappingProfile>();}).CreateMapper();    
       }
    }
}