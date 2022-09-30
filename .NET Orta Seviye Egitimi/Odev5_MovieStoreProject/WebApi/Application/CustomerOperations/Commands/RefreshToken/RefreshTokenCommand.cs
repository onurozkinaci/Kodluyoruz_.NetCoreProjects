using System;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Webapi.TokenOperations.Models;
using WebApi.DbOperations;

namespace WebApi.Application.CustomerOperations.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {
        public string RefreshToken {get; set;} 
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public RefreshTokenCommand(IMovieStoreDbContext dbContext,IConfiguration configuration)
        {
          _dbContext = dbContext;
          _configuration = configuration;
        }

        public Token Handle()
        {
           var user =_dbContext.Customers.FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now); //refresh token'in expire date'i guncel zamandan buyuk olmazsa expire olmus ve artik kullanilamaz, yani yeni access token istediginde bulunamaz.
           //Ornegin, ekranda uzun sure islem yapmayan kullanici, refresh token icin max belirlenen sure olan 20dk(15+5) icerisinde islem yapmazsa refresh token ile yeniden access token uretemez cunku refresh token'in expire date'inin dolmasi buna engel olur.
           if(user is not null)
           {
             //Token yarat;
             TokenHandler handler = new TokenHandler(_configuration);
             Token token = handler.CreateAccessToken(user); //refresh token araciligiyla yeniden access token uretilir.

             //mevcut user'a olusturulan token bilgisi/degeri eklenir;
             user.RefreshToken = token.RefreshToken;
             user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5); //15dk olarak verilen access ve refresh token'in expiration time(date)'ina 5dk daha ekler
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