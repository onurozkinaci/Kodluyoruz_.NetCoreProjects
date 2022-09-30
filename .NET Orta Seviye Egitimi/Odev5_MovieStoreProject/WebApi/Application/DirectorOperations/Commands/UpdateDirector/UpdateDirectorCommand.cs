using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommand
    {
       public int DirectorId { get; set;}
       public UpdateDirectorModel Model {get; set;}
       private readonly MovieStoreDbContext _context;
       private readonly IMapper _mapper;
       public UpdateDirectorCommand(MovieStoreDbContext context, IMapper mapper)
       {
          _context = context;
          _mapper = mapper;
       }
       public void Handle()
       {
          var director = _context.Yonetmenler.SingleOrDefault(x=>x.Id == DirectorId);
          if(director is null)
             throw new InvalidOperationException("Guncellenecek oyuncu/aktor bulunamadi!");
             
          _mapper.Map(Model,director);    
          _context.SaveChanges();
       }
    }

    public class UpdateDirectorModel
    {
       public string Name { get; set; }
       public string Surname { get; set; }
    }
}