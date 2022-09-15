using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public GetBooksQuery(BookStoreDbContext dbContext)
        {
           _dbContext = dbContext;
        }

        /*BookController'daki GetBooks() yerine asagidaki Handle() metodu kullanilip artik istedigimiz
          formatta bir ViewModel donecegiz, tum entity'yi donup user'in UI'da gormesine gerek olmayan entity kolonlarini 
          gostermeyecegiz; 
        */
        public List<BooksViewNodel> Handle()
        {
           var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();
           List<BooksViewNodel> vm = new List<BooksViewNodel>();
           foreach(var book in bookList)
           {
             vm.Add(new BooksViewNodel()
             {
                Title = book.Title,
                Genre = ((GenreEnum)book.GenreId).ToString(),
                PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
                PageCount = book.PageCount
             });
           }
           return vm;  
        }

    }

    //UI'da user'a donecek olan model icin asagidaki gibi tanimlama yapilacak;
    public class BooksViewNodel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; } 
        public String Genre { get; set; }
    }
}