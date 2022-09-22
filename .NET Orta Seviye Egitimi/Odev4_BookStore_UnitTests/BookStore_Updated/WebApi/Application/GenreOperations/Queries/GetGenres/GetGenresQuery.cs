using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace Application.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
      //**UT(Unit Test) kapsaminda)-BookStoreDbContext'i direkt degil de interface uzerinden(IBookStoreDbContext) eklemek daha dogru olur, bagimliligi engellemek icin;
       public readonly IBookStoreDbContext _context;
       public readonly IMapper _mapper;
       public GetGenresQuery(IBookStoreDbContext context, IMapper mapper)
       {
            _context = context;
            _mapper = mapper;
       }

       public List<GenresViewModel> Handle()
       {
         var genres = _context.Genres.Where(x => x.IsActive).OrderBy(x => x.Id);
         List<GenresViewModel> returnObj = _mapper.Map<List<GenresViewModel>>(genres);
         return returnObj;
       }
    }

    public class GenresViewModel
    {
        public int Id {get;set;}
        public string Name { get; set; } //genre name
    }
}