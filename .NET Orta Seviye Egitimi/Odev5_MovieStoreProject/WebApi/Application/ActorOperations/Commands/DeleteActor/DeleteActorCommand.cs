using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommand
    {
        private readonly MovieStoreDbContext _context;
        public int ActorId { get; set;}
        public DeleteActorCommand(MovieStoreDbContext context)
        {
           _context = context;
        }
        
        public void Handle()
        {
           var actor = _context.Oyuncular.SingleOrDefault(x=>x.Id == ActorId);
           if(actor is null)
              throw new InvalidOperationException("Silinecek oyuncu/aktor bulunamadi!");

           if(_context.OyuncuFilm.Any(x => x.OyuncuId == ActorId))
              throw new InvalidOperationException("Bu oyuncu filmlerle iliskili oldugundan direkt buradan silinemez, oncelikle iliskili tablodan silinmelidir!");   

           _context.Oyuncular.Remove(actor);
           _context.SaveChanges();
        }
    }
}