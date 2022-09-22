using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Author
    {
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int Id { get; set;}
       public string Ad { get; set; } 
       public string Soyad { get; set; } 
       public DateTime DogumTarihi { get; set; } 

       public int BookId{get; set;} //Foreign Key for Book with the given 'Book' object below.
       public Book Book {get; set;}
    }
}
