using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
       public int GenreId {get;set;}

       //**UT(Unit Test) kapsaminda)-BookStoreDbContext'i direkt degil de interface uzerinden(IBookStoreDbContext) eklemek daha dogru olur, bagimliligi engellemek icin;
       public readonly IBookStoreDbContext _context;
       public readonly IMapper _mapper;
       public GetGenreDetailQuery(IBookStoreDbContext context, IMapper mapper)
       {
            _context = context;
            _mapper = mapper;
       }

       public GenreDetailViewModel Handle()
       {
         var genre = _context.Genres.SingleOrDefault(x => x.IsActive && x.Id == GenreId);
         if(genre is null)
            throw new InvalidOperationException("Kitap turu bulunamadi!");
            
         return _mapper.Map<GenreDetailViewModel>(genre);
       }
    }

    public class GenreDetailViewModel
    {
        public int Id {get;set;}
        public string Name { get; set; } //genre name
    }
}