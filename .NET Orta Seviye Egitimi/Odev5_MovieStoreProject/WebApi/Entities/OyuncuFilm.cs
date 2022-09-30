using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    //many to many relationship table(ara tablo) for Oyuncu and Film classes;
    public class OyuncuFilm
    {
       public int OyuncuId {get;set;}
       public Oyuncu Oyuncu { get; set; }
       public int FilmId {get;set;}
       public Film Film { get; set; } 
    }
}