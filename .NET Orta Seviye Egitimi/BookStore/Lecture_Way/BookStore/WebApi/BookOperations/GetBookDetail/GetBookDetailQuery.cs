using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.GetBookDetail
{
   public class GetBookDetailQuery
   {
      public int BookId {get; set;}
      private readonly BookStoreDbContext _dbContext;
      public GetBookDetailQuery(BookStoreDbContext dbContext)
      {
         _dbContext = dbContext;
      }
      public BookDetailViewModel Handle()
      {
         var book = _dbContext.Books.Where(book => book.Id == BookId).SingleOrDefault();
         if(book is null)
            throw new InvalidOperationException("Kitap mevcut degil!");
            
         BookDetailViewModel vm = new BookDetailViewModel();
         vm.Title = book.Title;
         vm.PageCount = book.PageCount;
         vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy");
         vm.Genre = ((GenreEnum)book.GenreId).ToString();
         return vm;     
      }
   }

   //UI'da user'a donecek olan viewmodel icin asagidaki gibi tanimlama yapilacak;
    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; } 
        public string Genre { get; set; }
    }
}