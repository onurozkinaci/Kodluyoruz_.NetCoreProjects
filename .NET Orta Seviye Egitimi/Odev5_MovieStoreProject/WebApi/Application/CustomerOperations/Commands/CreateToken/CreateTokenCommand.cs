using System;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Webapi.TokenOperations.Models;
using WebApi.DbOperations;

namespace WebApi.Application.CustomerOperations.Commands.CreateToken
{
    public class CreateTokenCommand
    {
        public CreateTokenModel Model {get; set;}
        
        //**UT(Unit Test) kapsaminda)-IMovieStoreDbContext'i direkt degil de interface uzerinden(IBookStoreDbContext) eklemek daha dogru olur, bagimliligi engellemek icin;
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper; //dep. injection kullanilarak AutoMapper eklendi.
        private readonly IConfiguration _configuration;

        public CreateTokenCommand(IMovieStoreDbContext dbContext,IConfiguration configuration, IMapper mapper)
        {
          _dbContext = dbContext;
          _mapper = mapper;
          _configuration = configuration;
        }
        public Token Handle()
        {
           var user =_dbContext.Customers.FirstOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
           if(user is not null)
           {
             //Token yarat;
             TokenHandler handler = new TokenHandler(_configuration);
             Token token = handler.CreateAccessToken(user);

             //mevcut user'a olusturulan token bilgisi/degeri eklenir;
             user.RefreshToken = token.RefreshToken;
             user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5); //15dk olarak verilen access ve refresh token'in expiration time(date)'ina 5dk daha ekler
             //ve en fazla 20 dk sonrasinda refresh tokenin guncellenmesi gerekir. Access token ile ayni anda olusturulan refresh token ile 20dk'dan sonra bir access token
             //daha alinmaya calisilirsa hata alinir, bu islem 20dk icerisinde gerceklestirilebilir.
             _dbContext.SaveChanges(); //Ilgili user bilgileri db'de guncellenir.
             return token;
           }
           
           //*Girilen bilgiler dogrultusunda user mevcut degilse 
           else
               throw new InvalidOperationException("Kullanici Adi - Sifre Hatali!");
        }
    }

    public class CreateTokenModel
    {
       public string Email { get; set;}  
       public string Password {get; set;} 
    }
}
