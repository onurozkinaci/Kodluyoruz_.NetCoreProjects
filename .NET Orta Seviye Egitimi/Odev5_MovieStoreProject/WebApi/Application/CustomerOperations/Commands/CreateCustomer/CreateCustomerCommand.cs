using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommand
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateCustomerModel Model{get;set;}

        public CreateCustomerCommand(MovieStoreDbContext context, IMapper mapper)
        {
           _context = context;
           _mapper = mapper;  
        }
        
        public void Handle()
        {
           var customer = _context.Customers.SingleOrDefault(x=>x.Email == Model.Email);
           if(customer is not null)
              throw new InvalidOperationException("Bu email ile bir kullanici zaten mevcut!");
            
            customer = _mapper.Map<Customer>(Model);
           _context.Add(customer);
           _context.SaveChanges();
        }
    }

    public class CreateCustomerModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
