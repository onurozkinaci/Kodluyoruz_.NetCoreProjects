using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Oyuncu
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //for auto increment of id.
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<OyuncuFilm> OyuncuFilm { get; set; } //many to many iliski
    }   
}