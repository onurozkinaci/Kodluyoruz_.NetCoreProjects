using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.DirectorOperations.Queries.GetDirectors
{
    public class GetDirectorsQuery
    {
      private readonly MovieStoreDbContext _context;
       private readonly IMapper _mapper;
       public GetDirectorsQuery(MovieStoreDbContext context, IMapper mapper)
       {
          _context = context;
          _mapper = mapper;
       }
       public List<DirectorVM> Handle()
       {
          var yonetmenler = _context.Yonetmenler.OrderBy(x=>x.Id).ToList<Yonetmen>();
          List<DirectorVM> vm = _mapper.Map<List<DirectorVM>>(yonetmenler);
          return vm;
       }
    }

    public class DirectorVM //Actor View Model will be returned as a response to user, which includes required infos.
    {
       public string Name { get; set; }
       public string Surname { get; set; }    
    }
}