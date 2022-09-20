using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.Application.BookOperations.Queries.GetBookDetail
{
   public class GetBookDetailQuery
   {
      public int BookId {get; set;}
      private readonly BookStoreDbContext _dbContext;
      private readonly IMapper _mapper;
      public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
      {
         _dbContext = dbContext;
         _mapper = mapper;
      }
      public BookDetailViewModel Handle()
      {
         //=>"Include" ile join mantigini kullanarak Genre tablosuna da dahil ettik aramaya(Foreign Key);
         var book = _dbContext.Books.Include(x => x.Genre).Where(book => book.Id == BookId).SingleOrDefault();
         if(book is null)
            throw new InvalidOperationException("Kitap mevcut degil!");

         BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book); //AutoMapper ile entity'yi VM'ye mapleme.
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