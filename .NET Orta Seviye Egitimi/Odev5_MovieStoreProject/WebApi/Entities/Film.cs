using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Film
    {
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //for auto increment of id.
        public int Id { get; set; }
        public string Name { get; set; }

        public int GenreId { get; set;} //Foreign Key for Film with the given 'Genre' object below.
        public Genre Genre { get; set; }

        public double Price { get; set; }
        
        //One to many iliski;
        //Bir filmin bir yonetmeni vardir fakat bir yonetmen birden cok film yonetebilir.
        public int YonetmenId { get; set; } //Foreign Key for Film with the given 'Yonetmen' object below.
        public Yonetmen Yonetmen { get; set; }

        //Many to many iliski;
        public ICollection<OyuncuFilm> OyuncuFilm { get; set; }
        public ICollection<Siparislerim> SatinAlinanFilmler { get; set; }
    }

    /*public enum Genre
    {
       Science_Fiction = 1, Romance, Comedy, Horror, Action, Dram
    }*/
}