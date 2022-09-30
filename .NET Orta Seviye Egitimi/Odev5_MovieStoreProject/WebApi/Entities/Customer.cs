using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //for auto increment of id.
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //**Authentication islemleri icin 'RefreshToken' propertysi tanimlandi;
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireDate { get; set; } //'?' propertynin nullable oldugunu belirtir.

        //public List<Genre> FavoriteGenres { get; set; } //tur sinifi acarsan burasi Genre enum'i yerine class'i tip olarak alabilir.
        public ICollection<Siparislerim> SatinAlinanFilmler { get; set; }  
    }
}