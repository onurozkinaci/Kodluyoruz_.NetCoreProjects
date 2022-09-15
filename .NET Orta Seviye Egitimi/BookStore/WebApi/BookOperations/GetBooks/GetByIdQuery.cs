using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.GetBooks
{
   public class GetByIdQuery
   {
      public int sentId {get; set;}
      private readonly BookStoreDbContext _dbContext;
      public GetByIdQuery(BookStoreDbContext dbContext)
      {
         _dbContext = dbContext;
      }
      public  BookVM Handle()
      {
         var book = _dbContext.Books.Where(book => book.Id == sentId).SingleOrDefault();
         BookVM vm = new BookVM()
         {
           Title = book.Title,
           PageCount = book.PageCount,
           PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
           Genre = ((GenreEnum)book.GenreId).ToString()
         };
         return vm;     
      }
   }

   //UI'da user'a donecek olan viewmodel icin asagidaki gibi tanimlama yapilacak;
    public class BookVM
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; } 
        public String Genre { get; set; }
    }
}