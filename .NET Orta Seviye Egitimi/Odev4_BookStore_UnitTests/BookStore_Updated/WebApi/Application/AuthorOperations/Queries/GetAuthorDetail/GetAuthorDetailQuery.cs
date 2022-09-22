using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
      //**UT(Unit Test) kapsaminda)-BookStoreDbContext'i direkt degil de interface uzerinden(IBookStoreDbContext) eklemek daha dogru olur, bagimliligi engellemek icin;
       private readonly IBookStoreDbContext _context;
       private readonly IMapper _mapper;
       public int AuthorId {get; set;}
       public GetAuthorDetailQuery(IBookStoreDbContext context, IMapper mapper)
       {
          _context = context;
          _mapper = mapper;
       }
       public AuthorDetailVM Handle()
       {
          var author = _context.Authors.Include(x=>x.Book).SingleOrDefault(x => x.Id == AuthorId);
          if(author is null)
             throw new InvalidOperationException("Bu id'ye ait yazar bulunamadi!");
          
          return _mapper.Map<AuthorDetailVM>(author);
       }
    }
    public class AuthorDetailVM
    {
       public string FullName {get; set;}
       public string DogumTarihi { get; set; }   
       public string Book { get; set; }   
    }
}