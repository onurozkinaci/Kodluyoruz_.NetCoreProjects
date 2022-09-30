using WebApi.DbOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Customers
    {
        public static void AddCustomers(this MovieStoreDbContext context) //MovieStoreDbContext uzerinden extension metot olarak cagrilabilecek.
        {
           context.Customers.AddRange(
               new Customer {Name = "Ahmet", Surname = "Demir", Email = "ademir@gmail.com", Password = "123456"},
               new Customer {Name = "Ali", Surname = "Duran", Email = "aduran@gmail.com", Password = "12345"},
               new Customer {Name = "Beyza", Surname = "Saran", Email = "bsaran@gmail.com", Password = "123456"}
           );
        }
    }
}