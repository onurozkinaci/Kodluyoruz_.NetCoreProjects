using AutoMapper;
using WebApi.DbOperations;
using WebApi.TokenOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.StudentOperations.Commands.CreateToken
{
   public class CreateTokenCommand
   {
      private readonly IUniManSystemDbContext _context;
      private readonly IMapper _mapper;
      private readonly IConfiguration _configuration;
      public CreateTokenModel Model { get; set; }
      public CreateTokenCommand(IUniManSystemDbContext context, IMapper mapper, IConfiguration configuration)
      {
          _context = context;
          _mapper = mapper;
          _configuration = configuration;
      }
      public Token Handle()
      {
         var student = _context.Students.FirstOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
         if(student is not null)
         {
            //Token yarat;
            TokenHandler handler = new TokenHandler(_configuration);
            Token token = handler.CreateAccessToken(student);

            //mevcut user'a olusturulan token bilgisi/degeri eklenir;
            student.RefreshToken = token.RefreshToken;
            student.RefreshTokenExpireDate = token.Expiration.AddMinutes(5); //15+5 = 20dk
            _context.SaveChanges(); //Ilgili user bilgileri db'de guncellenir.
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