using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.FilmOperations.Commands.DeleteFilm
{
    public class DeleteFilmCommand
    {
       public int FilmId { get; set;}
       private readonly MovieStoreDbContext _context;
       public DeleteFilmCommand(MovieStoreDbContext context)
       {
          _context = context;
       }
       public void Handle()
       {
          var film = _context.Films.SingleOrDefault(x=>x.Id == FilmId);
          if(film is null)
             throw new InvalidOperationException("Silinecek film bulunamadi!");

          if(_context.OyuncuFilm.Any(x => x.FilmId == FilmId))
              throw new InvalidOperationException("Bu film oyuncularla iliskili oldugundan direkt buradan silinemez, oncelikle iliskili tablodan silinmelidir!");   

          if(_context.Siparisler.Any(x => x.FilmId == FilmId))
           {   
             //*Birden cok kayit donebileceginden(many to many iliski) SingleOrDefault() hata verebilir,
              //bu sebeple FirstOrDefault() kullanmak daha dogru;
              var order = _context.Siparisler.FirstOrDefault(x=>x.FilmId == FilmId);
              //*Siparislerimde herhangi bir aktif kaydi bulunan bir musteri buradan silinemez, ilk once siparislerimden silinmeli/pasif hale getirilmeli(isActive = false olacak sekilde);
              if(order.IsActive == true)
                 throw new InvalidOperationException("Satin alinan bir film buradan direkt silinemez, oncelikle siparislerden silinmelidir!"); 
           }     
              
          _context.Films.Remove(film);  
          _context.SaveChanges();
       }
    }
}