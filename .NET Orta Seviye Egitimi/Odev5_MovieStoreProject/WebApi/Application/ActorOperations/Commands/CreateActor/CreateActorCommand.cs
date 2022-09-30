using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommand
    {
       private readonly MovieStoreDbContext _context;
       private readonly IMapper _mapper;
       public CreateActorModel Model {get;set;}
       public CreateActorCommand(MovieStoreDbContext context, IMapper mapper)
       {
          _context = context;
          _mapper = mapper;
       }
       public void Handle()
       {
          var actor = _context.Oyuncular.SingleOrDefault(x=>x.Name == Model.Name && x.Surname == Model.Surname);
          if(actor is not null)
             throw new InvalidOperationException("Bu ad-soyad ile bir oyuncu kaydi zaten mevcut!");
             
           actor = _mapper.Map<Oyuncu>(Model);
          _context.Oyuncular.Add(actor);
          _context.SaveChanges();
       }
    }

    public class CreateActorModel
    {
       public string Name { get; set;}
       public string Surname { get; set;}
    }
}