using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WebApi.Services;

namespace WebApi.Middlewares
{
    public class CustomExceptionMiddleware
    {
      private readonly RequestDelegate _next;
      private readonly ILoggerService _loggerService; //DI Container'a startup'ta inject edilen/eklenen servis alinip
      //constructor'da dependency injection saglanacak sekilde atamasi saglanir.

      public CustomExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
      {
         _next = next;
         _loggerService = loggerService;
      }
      public async Task Invoke(HttpContext context)
      {
         var watch = Stopwatch.StartNew(); //Stopwatch ile bir izleme/timer mekanizmasi icin islem baslar ve amacimiz request sonrasinda response'un ne kadar surede dondugunu gormek.
         try
         {
            string message = "[Request]  HTTP " + context.Request.Method + " - " + context.Request.Path;
            //Console.WriteLine(message);
            _loggerService.Write(message); //=> Console.WriteLine()) ile yazmak yerine artik dependency injection baglaminda ekledigimiz servis ile ekleme yapiyoruz.
            await _next(context); //bir sonraki middleware'i cagirir => "await _next.Invoke(context);" => startup.cs'de bundan sonra gelen middleware endpointleri tetikliyor, bu sayede response alinabilecek.
            /***Bir ustteki satir ile bundan sonraki middleware(endpointleri tetikleyen) calisacagindan ve bunlar icin validasyon(Fluent validation kutuphanesi kullanildi) veya veri ile ilgili hata alinirsa 
            program burada catch'e dusup bir alt satirdaki  watch.Stop() calismayacagindan zamanlayici durmaz, bu sebeple catch icerisine de onu veriyoruz.
            */
            watch.Stop(); //izlemeyi durdurur ve ustteki baslangic ve buradaki bitis zamanin farki da asagidaki satirdaki kodla log'a yazdirilacak.
            message = "[Response] HTTP " + context.Request.Method + " - " + context.Request.Path 
            + " responded with " + context.Response.StatusCode + " in " +watch.Elapsed.TotalMilliseconds+ " ms.";
            //Console.WriteLine(message);
            _loggerService.Write(message);
         }
         catch(Exception ex) //await _next(context); ile bir sonraki middleware olan ve endpointleri calistiran "app.UseEndpoints"'te hata alinirsa/post
         //isleminin validasyonu vs. icin, burada hata kontrolu yapilir ve istedigimiz formatta loglanarak ekrana ve konsola basilacak.
         {
             watch.Stop();
             await HandleException(context,ex,watch);
         }
      }

        private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
        {
          context.Response.ContentType = "application/json";
          context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
          string message = "[Error]  HTTP " + context.Request.Method + " - " + context.Response.StatusCode + " Error Message " + ex.Message
          + " in " + watch.Elapsed.TotalMilliseconds + " ms.";
          //Console.WriteLine(message);
          _loggerService.Write(message);
          //*"dotnet add package Newtonsoft.Json package Newtonsoft.Json" komutu ile bu Json kutuphanesini terminalden projemize ekleyerek, hata mesajini
          //Json olarak kolayca donebiliriz - Object serialization ile objeyi Json'a donusturuyoruz;
          var result = JsonConvert.SerializeObject( new { error = ex.Message}, Formatting.None);
          return context.Response.WriteAsync(result);
        }
    }
   //startup.cs'de app. prefix'i ile cagirabilmek icin Extension metot tanimlanir;
    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomException(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}