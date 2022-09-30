using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DbOperations;

namespace TestSetup
{
    public class CommonTestFixture
    {
        public MovieStoreDbContext Context { get; set; }
        public IMapper Mapper { get; set; }
        
        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<MovieStoreDbContext>().UseInMemoryDatabase(databaseName:"MovieStoreTestDb").Options;
            Context = new MovieStoreDbContext(options);
            Context.Database.EnsureCreated();

            //*InMemory db ilk olustugunda Db'nin bos olmamasi, default degerle baslatilmasi icin;
            Context.AddCustomers();
            Context.AddMovies();
            Context.AddActors();
            Context.AddActorMovies();
            Context.AddOrders();
            Context.AddDirectors();
            Context.SaveChanges();

            Mapper = new MapperConfiguration(cfg => {cfg.AddProfile<MappingProfile>();}).CreateMapper();
        }

    }
}