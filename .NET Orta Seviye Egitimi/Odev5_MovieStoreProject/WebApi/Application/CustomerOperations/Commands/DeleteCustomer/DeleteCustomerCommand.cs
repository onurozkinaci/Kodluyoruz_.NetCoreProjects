using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand
    {
        private readonly MovieStoreDbContext _context;
        public int CustomerId { get; set;}
        public DeleteCustomerCommand(MovieStoreDbContext context)
        {
           _context = context;
        }
        
        public void Handle()
        {
           var customer = _context.Customers.SingleOrDefault(x=>x.Id == CustomerId);
           if(customer is null)
              throw new InvalidOperationException("Silinecek musteri bulunamadi!");

           if(_context.Siparisler.Any(x => x.CustomerId == CustomerId))
           {   
              //*Birden cok kayit donebileceginden(many to many iliski) SingleOrDefault() hata verebilir,
              //bu sebeple FirstOrDefault() kullanmak daha dogru;
              var order = _context.Siparisler.FirstOrDefault(x=>x.CustomerId == CustomerId);
              //*'Siparislerim'de herhangi bir aktif kaydi bulunan bir musteri buradan silinemez, ilk once siparislerimden silinmeli/pasif hale getirilmeli(isActive = false olacak sekilde);
              if(order.IsActive == true)
                 throw new InvalidOperationException("Film satin almis bir musteri buradan direkt silinemez, oncelikle siparislerden kaydi silinmelidir!");
           } 
           
           _context.Customers.Remove(customer);
           _context.SaveChanges();
        }
    }
}