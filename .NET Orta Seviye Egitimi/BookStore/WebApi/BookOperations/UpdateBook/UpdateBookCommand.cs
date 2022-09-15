using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
       public string CurrentTitle { get; set; }
       public UpdateBookModel Model {get; set;}
       private readonly BookStoreDbContext _dbContext;
       public UpdateBookCommand(BookStoreDbContext dbContext)
       {
         _dbContext = dbContext;
       }

       public void Handle()
       {
          var book = _dbContext.Books.SingleOrDefault(x => x.Title == CurrentTitle);
          if(book is null) //guncellenmek istenen kitap db'de mevcut olmali
             throw new InvalidOperationException("Kitap bulunamadi!");
        
          //Validasyon kontrolu dogrultusunda ilgili kolonlarin degerini guncelleme;
          book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
          book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
          book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
          book.Title = Model.Title != default ? Model.Title : book.Title;
          _dbContext.SaveChanges();
       }
    }
    
    //ViewModel ile donecek object icin degil de kullanicidan FromBody ile parametre olarak alinan
    //body icerisindeki object'te neler gerektigine karar verecek model yapisi asagida tanimlandi;
    public class UpdateBookModel
    {
       public string Title { get; set;}  
       public int GenreId { get; set;}  

       public int PageCount { get; set;}

       public DateTime PublishDate { get; set;}
    }
}