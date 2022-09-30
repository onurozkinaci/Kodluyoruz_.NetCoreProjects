using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.FilmOperations.Commands.CreateFilm
{
    public class CreateFilmCommand
    {
       public CreateFilmModel Model {get; set;}
       private readonly MovieStoreDbContext _context;
       private readonly IMapper _mapper;
       public CreateFilmCommand(MovieStoreDbContext context, IMapper mapper)
       {
          _context = context;
          _mapper = mapper;
       }
       public void Handle()
       {
          var film = _context.Films.SingleOrDefault(x=>x.Name == Model.Name);
          if(film is not null)
             throw new InvalidOperationException("Bu isimde bir film zaten mevcut!");
             
          film = _mapper.Map<Film>(Model);
          _context.Films.Add(film);
          _context.SaveChanges();
       }
    }

    public class CreateFilmModel
    {
       public string Name { get; set; }
       public int GenreId { get; set; }
       public double Price { get; set; }
       public int YonetmenId { get; set; }
    }
}