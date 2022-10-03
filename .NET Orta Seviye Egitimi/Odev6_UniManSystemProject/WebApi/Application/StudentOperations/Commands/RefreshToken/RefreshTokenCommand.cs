using WebApi.DbOperations;
using WebApi.TokenOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.Application.CustomerOperations.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {
        public string RefreshToken {get; set;}
        
        //**UT(Unit Test) kapsaminda)-IMovieStoreDbContext'i direkt degil de interface uzerinden(IBookStoreDbContext) eklemek daha dogru olur, bagimliligi engellemek icin;
        private readonly IUniManSystemDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public RefreshTokenCommand(IUniManSystemDbContext dbContext,IConfiguration configuration)
        {
          _dbContext = dbContext;
          _configuration = configuration;
        }

        public Token Handle()
        {
           var student =_dbContext.Students.FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now); //refresh token'in expire date'i guncel zamandan buyuk olmazsa expire olmus ve artik kullanilamaz, yani yeni access token istediginde bulunamaz.
           //Ornegin, ekranda uzun sure islem yapmayan kullanici, refresh token icin max belirlenen sure olan 20dk(15+5) icerisinde islem yapmazsa refresh token ile yeniden access token uretemez cunku refresh token'in expire date'inin dolmasi buna engel olur.
           if(student is not null)
           {
             //Token yarat;
             TokenHandler handler = new TokenHandler(_configuration);
             Token token = handler.CreateAccessToken(student); //refresh token araciligiyla yeniden access token uretilir.

             //mevcut user'a/student olusturulan refresh token bilgisi/degeri eklenir;
             student.RefreshToken = token.RefreshToken;
             student.RefreshTokenExpireDate = token.Expiration.AddMinutes(5); //15dk olarak verilen access ve refresh token'in expiration time(date)'ina 5dk daha ekler
             //ve en fazla 20 dk sonrasinda refresh tokenin guncellemesi gerekir.
             _dbContext.SaveChanges(); //Ilgili user bilgileri db'de guncellenir.
             return token;
           }
           
           //*Girilen bilgiler dogrultusunda user mevcut degilse 
           else
               throw new InvalidOperationException("Valid bir Refresh Token bulunamadi!");
        }
    }
}
