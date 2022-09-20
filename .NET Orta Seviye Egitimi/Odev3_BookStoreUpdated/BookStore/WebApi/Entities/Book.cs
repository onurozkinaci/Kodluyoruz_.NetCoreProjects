using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Book
    {
        //Id icin db'de auto increment saglamak adina asagidaki attribute verilir;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}
        public string Title { get; set; }
        //Bu sekide integer olarak belirttigin GenreId altinda Genre sinifindan
        //olusturdugun objeyi vererek aslinda Foreign Key tanimlamis oluyorsun.
        public int GenreId { get; set; } //Foreign Key for Genre with the given 'Genre' object below.
        public Genre Genre { get; set; } 
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set;}
    }
}
