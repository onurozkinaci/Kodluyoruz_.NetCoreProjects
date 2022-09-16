using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
       public int BookId { get; set; }
       public UpdateBookModel Model {get; set;}
       private readonly BookStoreDbContext _dbContext;
       private readonly IMapper _mapper; //To use AutoMapper with dependency injection
       public UpdateBookCommand(BookStoreDbContext dbContext, IMapper mapper)
       {
         _dbContext = dbContext;
         _mapper = mapper;
       }

       public void Handle()
       {
          var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
          if(book is null) //guncellenmek istenen kitap db'de mevcut olmali
             throw new InvalidOperationException("Guncellenecek Kitap bulunamadi!");
        
          //Validasyon kontrolu dogrultusunda ilgili kolonlarin degerini guncelleme;
          /*book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
          book.Title = Model.Title != default ? Model.Title : book.Title;
          */
          //=>Ustteki islemi refactor ederek AutoMapper ile asagidaki gibi kullanabiliriz;
          //Console.WriteLine(book.Id.ToString()+"-"+book.GenreId+"-"+book.Title+"-"+book.PageCount+"-"+book.PublishDate);
          _mapper.Map(Model,book); //_mapper.Map<book>(Model); ile  hata veriyor, Book olarak verirsen de yeni obje olusturup guncellemiyor, su an verilen sekilde guncelliyor.
          //Console.WriteLine(book.Id.ToString()+"-"+book.GenreId+"-"+book.Title+"-"+book.PageCount+"-"+book.PublishDate);
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