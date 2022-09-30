using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.OrderOperations.Commands.DeleteOrder
{
    public class DeleteOrderCommand
    {
        private readonly MovieStoreDbContext _context;
        public int CustomerId { get; set;}
        public int FilmId { get; set;}
        public DeleteOrderCommand(MovieStoreDbContext context)
        {
           _context = context;
        }
        
        public void Handle()
        {
           var order = _context.Siparisler.SingleOrDefault(x=>x.CustomerId == CustomerId && x.FilmId == FilmId);
           if(order is null)
              throw new InvalidOperationException("Silinecek siparis bulunamadi!");

            order.IsActive = false; //aktif oldugunu belirten ozellik guncellenir, sistemden hard olarak silinmez!
           _context.SaveChanges();
        }
    }
}