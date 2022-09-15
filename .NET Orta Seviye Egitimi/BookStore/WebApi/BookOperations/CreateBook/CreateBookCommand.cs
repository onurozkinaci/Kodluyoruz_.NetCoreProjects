using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model {get; set;}
        private readonly BookStoreDbContext _dbContext;
        public CreateBookCommand(BookStoreDbContext dbContext)
        {
          _dbContext = dbContext;
        }
        public void Handle()
        {
           var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title); //model tipinde kullanicidan veri alinan bidy kismindan gelen title ile db'den cekilen kayitlari kiyaslar.
           if(book is not null) //"book != null" eklenen kitap onceden db'de mevcut ise tekrar eklenmesine izin verme!
              throw new InvalidOperationException("Kitap zaten mevcut!");
           book = new Book();
           book.Title = Model.Title;  
           book.PublishDate = Model.PublishDate;
           book.PageCount = Model.PageCount;
           book.GenreId = Model.GenreId;
           _dbContext.Books.Add(book);
           _dbContext.SaveChanges();
        }
    }

    //ViewModel ile donecek object icin degil de kullanicidan FromBody ile parametre olarak alinan
    //body icerisindeki object'te neler gerektigine karar verecek model yapisi asagida tanimlandi;
    public class CreateBookModel
    {
       public string Title { get; set;}  
       public int GenreId { get; set;}  

       public int PageCount { get; set;}

       public DateTime PublishDate { get; set;}
    }
}
