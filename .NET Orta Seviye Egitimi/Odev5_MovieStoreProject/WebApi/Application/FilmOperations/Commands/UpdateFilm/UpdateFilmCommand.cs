using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.FilmOperations.Commands.UpdateFilm
{
    public class UpdateFilmCommand
    {
       public int FilmId { get; set;}
       public UpdateFilmModel Model {get; set;}
       private readonly MovieStoreDbContext _context;
       private readonly IMapper _mapper;
       public UpdateFilmCommand(MovieStoreDbContext context, IMapper mapper)
       {
          _context = context;
          _mapper = mapper;
       }
       public void Handle()
       {
          var film = _context.Films.SingleOrDefault(x=>x.Id == FilmId);
          if(film is null)
             throw new InvalidOperationException("Guncellenecek film bulunamadi!");
             
          _mapper.Map(Model,film);    
          _context.SaveChanges();
       }
    }

    public class UpdateFilmModel
    {
       public string Name { get; set; }
       public int GenreId { get; set; }
       public double Price { get; set; }
       public int YonetmenId { get; set; }
    }
}