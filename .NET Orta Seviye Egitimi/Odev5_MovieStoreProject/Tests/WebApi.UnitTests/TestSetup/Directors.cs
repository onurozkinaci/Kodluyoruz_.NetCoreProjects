using WebApi.DbOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Directors
    {
        public static void AddDirectors(this MovieStoreDbContext context)
        {
           context.Yonetmenler.AddRange(
              new Yonetmen{ Name = "David", Surname = "Fincher"},
              new Yonetmen{Name = "Zeki",Surname = "Demirkubuz"}
           );
        }
    }
}