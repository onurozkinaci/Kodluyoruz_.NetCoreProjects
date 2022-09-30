using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommand
    {
        private readonly MovieStoreDbContext _context;
        public int DirectorId { get; set;}
        public DeleteDirectorCommand(MovieStoreDbContext context)
        {
           _context = context;
        }
        
        public void Handle()
        {
           var director = _context.Yonetmenler.SingleOrDefault(x=>x.Id == DirectorId);
           if(director is null)
              throw new InvalidOperationException("Silinecek yonetmen bulunamadi!");

           if(_context.Films.Any(x => x.YonetmenId == DirectorId))
              throw new InvalidOperationException("Filmi bulunan bir yonetmen direkt buradan silinemez, oncelikle ilgili tablodan silinmelidir!");
                
           _context.Yonetmenler.Remove(director);
           _context.SaveChanges();
        }
    }
}