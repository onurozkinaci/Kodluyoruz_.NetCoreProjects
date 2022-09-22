using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.BookOperations.Queries.GetBooks
{
    public class GetBooksQuery
    {
        //**UT(Unit Test) kapsaminda)-BookStoreDbContext'i direkt degil de interface uzerinden(IBookStoreDbContext) eklemek daha dogru olur, bagimliligi engellemek icin;
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBooksQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
           _dbContext = dbContext;
           _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
           var bookList = _dbContext.Books.Include(x=> x.Genre).OrderBy(x => x.Id).ToList<Book>();
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
        public string Genre { get; set; }
    }
}