using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.OrderOperations.Queries.GetOrders
{
    public class GetOrdersQuery
    {
      private readonly MovieStoreDbContext _context;
       private readonly IMapper _mapper;
       public GetOrdersQuery(MovieStoreDbContext context, IMapper mapper)
       {
          _context = context;
          _mapper = mapper;
       }
       public List<OrderVM> Handle()
       {
          var orders = _context.Siparisler.Include(x=>x.Customer).Include(x=>x.Film).OrderBy(x=>x.CustomerId).ToList<Siparislerim>();
          List<OrderVM> vm = _mapper.Map<List<OrderVM>>(orders);
          return vm;
       }
    }

    public class OrderVM
    {
       public string Customer { get; set; }
       public string Film { get; set; }
       public double Fiyat { get; set; }
       public string SatinAlmaTarihi { get; set; }
       public bool IsActive { get; set;}
    }
}