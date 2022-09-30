using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.ActorOperations.Queries.GetActors
{
    public class GetActorsQuery
    {
      private readonly MovieStoreDbContext _context;
       private readonly IMapper _mapper;
       public GetActorsQuery(MovieStoreDbContext context, IMapper mapper)
       {
          _context = context;
          _mapper = mapper;
       }
       public List<ActorVM> Handle()
       {
          var oyuncular = _context.Oyuncular.OrderBy(x=>x.Id).ToList<Oyuncu>();
          List<ActorVM> vm = _mapper.Map<List<ActorVM>>(oyuncular);
          return vm;
       }
    }

    public class ActorVM //Actor View Model will be returned as a response to user, which includes required infos.
    {
       public string Name { get; set; }
       public string Surname { get; set; }    
    }
}