using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommand
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateOrderModel Model{get;set;}

        public CreateOrderCommand(MovieStoreDbContext context, IMapper mapper)
        {
           _context = context;
           _mapper = mapper;  
        }
        
        public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(s => s.Id == Model.CustomerId);
            var movies = _context.Films.SingleOrDefault(s => s.Id == Model.FilmId);
            if (customer is null)
                throw new InvalidOperationException("Müşteri bulunamadı!");
            if (movies is null)
                throw new InvalidOperationException("Film bulunamadı!");
            var order = _context.Siparisler.SingleOrDefault(x=>x.CustomerId == Model.CustomerId && x.FilmId == Model.FilmId);
            if(order is not null)
               throw new InvalidOperationException("Bu musteri-film icin bir kayit zaten mevcut!");
            
            order = _mapper.Map<Siparislerim>(Model);
           _context.Add(order);
           _context.SaveChanges();
        }
    }

    public class CreateOrderModel
    { 
       public int CustomerId {get;set;}
       public int FilmId {get;set;}
       public double Fiyat { get; set; }
       public DateTime SatinAlmaTarihi { get; set;}
    }
}