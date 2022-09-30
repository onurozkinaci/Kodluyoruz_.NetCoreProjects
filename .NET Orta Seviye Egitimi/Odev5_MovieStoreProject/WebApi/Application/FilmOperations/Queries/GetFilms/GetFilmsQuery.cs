using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.FilmOperations.Queries.GetFilms
{
    public class GetFilmsQuery
    {
       private readonly MovieStoreDbContext _context;
       private readonly IMapper _mapper;
       public GetFilmsQuery(MovieStoreDbContext context, IMapper mapper)
       {
          _context = context;
          _mapper = mapper;
       }
       public List<MovieVM> Handle()
       {
          var films = _context.Films.Include(x => x.Genre).Include(x=>x.Yonetmen).OrderBy(x=>x.Id).ToList<Film>();
          List<MovieVM> vm = _mapper.Map<List<MovieVM>>(films);
          return vm;
       }
    }

    public class MovieVM
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
        public string Yonetmen { get; set;}
    }
}