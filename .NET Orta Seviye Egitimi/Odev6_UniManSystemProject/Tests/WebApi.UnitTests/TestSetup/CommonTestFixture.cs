using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Common;
using WebApi.DbOperations;

namespace Test.WebApi.UnitTests.TestSetup
{
   public class CommonTestFixture
   {
      public UniManSystemDbContext Context { get; set; }
      public IMapper Mapper { get; set; }

      public CommonTestFixture()
      {
        var options = new DbContextOptionsBuilder<UniManSystemDbContext>().UseInMemoryDatabase(databaseName: "UniManSystemTestDb").Options;
        Context = new UniManSystemDbContext(options);
        Context.Database.EnsureCreated(); //database'in olusturulup olusturulmadigindan emin olunur.

        //*InMemory db ilk olustugunda Db'nin bos olmamasi, default degerle baslatilmasi icin;
        Context.AddCourses();
        Context.AddDepartments();
        Context.AddSelectedCourses();
        Context.AddStudents();
        Context.AddTeachers();
        Context.SaveChanges(); //en son db'ye eklemeyi tamamlamak-commit basmak icin.
        
        //*Context tanimi yukaridaki gibi bittikten sonra, Mapper config'ini de olasi degisiklikler test'i engellemesin diye WebApi altinda olusturmus oldugumuz MappingProfile'daki map tanimlarini konfigure ederek
        //atiyoruz, calistiriyoruz;
        Mapper = new MapperConfiguration(cfg => {cfg.AddProfile<MappingProfile>();}).CreateMapper();    
      }
   }
}