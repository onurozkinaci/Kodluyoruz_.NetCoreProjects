using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.GetAuthors
{
    public class GetAuthorsQuery
    {
       private readonly BookStoreDbContext _context;
       private readonly IMapper _mapper;
       public GetAuthorsQuery(BookStoreDbContext context, IMapper mapper)
       {
          _context = context;
          _mapper = mapper;
       }
       public List<AuthorVM> Handle()
       {
          var authors = _context.Authors.Include(x=>x.Book).OrderBy(x => x.Id).ToList<Author>();
          List<AuthorVM> vm = _mapper.Map<List<AuthorVM>>(authors);
          return vm;
       }
    }

    public class AuthorVM
    {
       public string FullName {get; set;}
       public string DogumTarihi { get; set; }  
       public string Book { get; set;}   
    }
}