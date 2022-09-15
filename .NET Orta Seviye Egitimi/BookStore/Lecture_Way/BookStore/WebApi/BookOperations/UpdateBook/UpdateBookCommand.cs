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
       public int BookId { get; set; }
       public UpdateBookModel Model {get; set;}
       private readonly BookStoreDbContext _dbContext;
       public UpdateBookCommand(BookStoreDbContext dbContext)
       {
         _dbContext = dbContext;
       }

       public void Handle()
       {
          var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
          if(book is null) //guncellenmek istenen kitap db'de mevcut olmali
             throw new InvalidOperationException("Guncellenecek Kitap bulunamadi!");
        
          //Validasyon kontrolu dogrultusunda ilgili kolonlarin degerini guncelleme;
          book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
          book.Title = Model.Title != default ? Model.Title : book.Title;
          _dbContext.SaveChanges();
       }
    }
    
    //Model, update icin daha da anlamli. Cunku bir entity icin her field update ettirilmeyebilir, cogu zaman da bu sekildedir;
    public class UpdateBookModel
    {
       public string Title { get; set;}  
       public int GenreId { get; set;}
    }
}