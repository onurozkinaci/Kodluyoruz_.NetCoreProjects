using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebApi.Entites;
using WebApi.TokenOperations.Models;

namespace WebApi.TokenOperations
{
    public class TokenHandler
    {
        public IConfiguration Configuration {get; set;}
        public TokenHandler(IConfiguration configuration)
        {
           Configuration = configuration;
        }
        public Token CreateAccessToken(Student user)
        {
            Token tokenModel = new Token();
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));
            SigningCredentials credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256); //hazir sifreleme algoritmalarindan birisi ile kimligi/key'i sifreliyoruz

            tokenModel.Expiration = DateTime.Now.AddMinutes(15); //15dk'lik bir access token yaratildi.

            //Token'in tipi JwtSecurityToken olarak olusturuldu;
            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: Configuration["Token:Issuer"],
                audience: Configuration["Token:Audience"],
                expires: tokenModel.Expiration,
                notBefore: DateTime.Now, //uretildigi andan ne kadar sonra kullanilsin? => direkt/simdi kullanilsin demis olduk.
                signingCredentials: credentials
            );
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            //Token yaratildi/uretildi;
            tokenModel.AccessToken = tokenHandler.WriteToken(securityToken);
            tokenModel.RefreshToken = CreateRefreshToken();
            return tokenModel;
        }

        public string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
     }

     
}
