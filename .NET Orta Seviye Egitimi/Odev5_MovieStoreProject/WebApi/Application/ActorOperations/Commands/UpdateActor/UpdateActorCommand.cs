using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommand
    {
       public int ActorId { get; set;}
       public UpdateActorModel Model {get; set;}
       private readonly MovieStoreDbContext _context;
       private readonly IMapper _mapper;
       public UpdateActorCommand(MovieStoreDbContext context, IMapper mapper)
       {
          _context = context;
          _mapper = mapper;
       }
       public void Handle()
       {
          var actor = _context.Oyuncular.SingleOrDefault(x=>x.Id == ActorId);
          if(actor is null)
             throw new InvalidOperationException("Guncellenecek oyuncu/aktor bulunamadi!");
             
          _mapper.Map(Model,actor);    
          _context.SaveChanges();
       }
    }

    public class UpdateActorModel
    {
       public string Name { get; set; }
       public string Surname { get; set; }
    }
}