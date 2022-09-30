using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommand
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateDirectorModel Model{get;set;}

        public CreateDirectorCommand(MovieStoreDbContext context, IMapper mapper)
        {
           _context = context;
           _mapper = mapper;  
        }
        
        public void Handle()
        {
           var director = _context.Yonetmenler.SingleOrDefault(x=>x.Name == Model.Name && x.Surname == Model.Surname);
           if(director is not null)
              throw new InvalidOperationException("Bu ad-soyad ile bir kayit zaten mevcut!");
            
            director = _mapper.Map<Yonetmen>(Model);
           _context.Add(director);
           _context.SaveChanges();
        }
    }

    public class CreateDirectorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}