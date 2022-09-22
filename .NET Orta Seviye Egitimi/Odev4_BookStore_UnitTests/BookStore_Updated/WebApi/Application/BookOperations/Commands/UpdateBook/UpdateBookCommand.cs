using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommand
    {
       public int BookId { get; set; }
       public UpdateBookModel Model {get; set;}

       //**UT(Unit Test) kapsaminda)-BookStoreDbContext'i direkt degil de interface uzerinden(IBookStoreDbContext) eklemek daha dogru olur, bagimliligi engellemek icin;
       private readonly IBookStoreDbContext _dbContext;
       private readonly IMapper _mapper; //To use AutoMapper with dependency injection
       public UpdateBookCommand(IBookStoreDbContext dbContext, IMapper mapper)
       {
         _dbContext = dbContext;
         _mapper = mapper;
       }

       public void Handle()
       {
          var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
          if(book is null) //guncellenmek istenen kitap db'de mevcut olmali
             throw new InvalidOperationException("Guncellenecek Kitap bulunamadi!");
          _mapper.Map(Model,book);
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