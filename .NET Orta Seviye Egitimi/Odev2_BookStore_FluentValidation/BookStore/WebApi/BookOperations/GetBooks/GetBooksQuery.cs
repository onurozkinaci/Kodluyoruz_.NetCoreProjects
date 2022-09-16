using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
           _dbContext = dbContext;
           _mapper = mapper;
        }

        /*BookController'daki GetBooks() yerine asagidaki Handle() metodu kullanilip artik istedigimiz
          formatta bir ViewModel donecegiz, tum entity'yi donup user'in UI'da gormesine gerek olmayan entity kolonlarini 
          gostermeyecegiz; 
        */
        public List<BooksViewModel> Handle()
        {
           var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();
           /*List<BooksViewModel> vm = new List<BooksViewModel>();
            foreach(var book in bookList)
           {
             vm.Add(new BooksViewModel()
             {
                Title = book.Title,
                Genre = ((GenreEnum)book.GenreId).ToString(),
                PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
                PageCount = book.PageCount
             });
           }*/ 
           //**Ustteki foreach kullanimi yerine direkt AutoMapper ile List halinde entityleri VM'e mapleyerek liste donuyoruz;
           List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);
           return vm;  
        }

    }

    //UI'da user'a donecek olan model icin asagidaki gibi tanimlama yapilacak;
    public class BooksViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; } 
        public String Genre { get; set; }
    }
}