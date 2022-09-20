using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.Commands.CreateAuthor
{
   public class CreateAuthorCommand
   {
       private readonly BookStoreDbContext _context;
       private readonly IMapper _mapper;
       public CreateAuthorModel Model {get; set;}
       public CreateAuthorCommand(BookStoreDbContext context, IMapper mapper)
       {
          _context = context;
          _mapper = mapper;
       }
       public void Handle()
       {
          var author = _context.Authors.SingleOrDefault(x => x.Ad == Model.Ad && x .Soyad == Model.Soyad);
          if(author is not null)
             throw new InvalidOperationException("Bu yazar zaten mevcut!");

          author = _mapper.Map<Author>(Model);
          if(_context.Authors.Any(x => x.BookId == author.BookId && x.Id != author.Id)) //baska bir yazar icin ayni kitabin atamasi yapilmissa ekleme yapilmaz cunku her kitabin bir yazar tarafindan yazilmasini istiyoruz.
            throw new InvalidOperationException("Bu kitap icin zaten bir yazar mevcut!");  

          if((_context.Books.SingleOrDefault(x => x.Id == author.BookId) is null)) //id'si mevcut olmayan bir kitap icin ekleme yapilirsa hata verilecek.
            throw new InvalidOperationException("Mevcut olmayan bir kitap icin ekleme yapilamaz!");      

          _context.Authors.Add(author);
          _context.SaveChanges();
       }
   }
   public class CreateAuthorModel
   {
       public string Ad { get; set; } 
       public string Soyad { get; set; } 
       public DateTime DogumTarihi { get; set;}
       public int BookId { get; set; }   
   }
}