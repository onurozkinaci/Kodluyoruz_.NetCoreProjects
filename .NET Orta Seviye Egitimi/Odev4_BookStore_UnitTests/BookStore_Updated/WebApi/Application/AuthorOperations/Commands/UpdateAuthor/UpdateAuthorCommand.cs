using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.Commands.UpdateAuthor
{
   public class UpdateAuthorCommand
   {  
        //**UT(Unit Test) kapsaminda)-BookStoreDbContext'i direkt degil de interface uzerinden(IBookStoreDbContext) eklemek daha dogru olur, bagimliligi engellemek icin;
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public int AuthorId;
        public UpdateAuthorModel Model {get; set;}
        public UpdateAuthorCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }    
        public void Handle()
        {
           var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
           if(author is null)
              throw new InvalidOperationException("Guncellenecek yazar bulunamadi!");
           
           //author.BookId = Model.BookId == default ? author.BookId : Model.BookId; //bos gonderilirse guncellenmeyecek, hata alinmamasi icin.       
           _mapper.Map(Model,author);
            if((_context.Books.SingleOrDefault(x => x.Id == author.BookId) is null))//boyle bir kitap mevcut degilse (girilen id'ye gore)
               throw new InvalidOperationException("Mevcut olmayan bir kitap icin guncelleme yapilamaz!");    
            _context.SaveChanges();
        }
   }
   public class UpdateAuthorModel
   {
       public string Ad { get; set; } 
       public string Soyad { get; set; } 
       public int BookId {get;set;}
   }
}