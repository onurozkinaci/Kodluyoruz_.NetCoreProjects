using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.Commands.DeleteAuthor
{
   public class DeleteAuthorCommand
   {
        private readonly BookStoreDbContext _context;
        public int AuthorId;
        public DeleteAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }    
        public void Handle()
        {
           var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
           if(author is null)
              throw new InvalidOperationException("Silinmek istenen yazar bulunamadi!");
           
           if(_context.Books.Any(x => x.Id == author.BookId))
              throw new InvalidOperationException("Guncel kitabi bulunan yazar silinemez, once kitap silinmeli!");    
              
           _context.Remove(author);
           _context.SaveChanges();
        }
   }
}