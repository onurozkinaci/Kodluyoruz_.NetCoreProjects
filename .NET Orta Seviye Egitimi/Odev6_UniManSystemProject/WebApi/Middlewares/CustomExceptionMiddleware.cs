using System.Diagnostics;
using System.Net;
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
         var watch = Stopwatch.StartNew(); //Stopwatch ile timer mekanizmasi kurularak response'un ne kadar surede dondugu gozlenir.
         try
         {
            string message = "[Request]  HTTP " + context.Request.Method + " - " + context.Request.Path;
            _loggerService.Write(message); //ILogger interface'inden miras alan ve startup'ta dep. injection mantigi ile uygulama baslatildiginda calisacak sinif uzerinden islem yapilir.
            await _next(context); //startup.cs'de kendinen bir sonraki middleware'i cagirir.
            watch.Stop(); //izlemeyi durdurur ve ustteki baslangic ve buradaki bitis zamanin farki da asagidaki satirdaki kodla log'a yazdirilacak.
            message = "[Response] HTTP " + context.Request.Method + " - " + context.Request.Path 
            + " responded with " + context.Response.StatusCode + " in " +watch.Elapsed.TotalMilliseconds+ " ms.";
            _loggerService.Write(message);
         }
         catch (Exception ex)
         {
            watch.Stop(); //try'da _next ile bir sonraki middleware cagrilirken hata alinip catch'e dusulurse de timer'in durdurulabilmesi icin.
            await HandleException(context,ex,watch);
         } 
      }
      public Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
      {
          context.Response.ContentType = "application/json";
          context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
          string message = "[Error]  HTTP " + context.Request.Method + " - " + context.Response.StatusCode + " Error Message " + ex.Message
          + " in " + watch.Elapsed.TotalMilliseconds + " ms.";
          _loggerService.Write(message);
          //*"JsonConvert.SerializeObject" from imported Newtonsoft.Json package";
          var result = JsonConvert.SerializeObject( new { error = ex.Message}, Formatting.None);
          return context.Response.WriteAsync(result);
      }     
   }

   public static class CustomExceptionMiddlewareExtension
   {
        public static IApplicationBuilder UseCustomException(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
   }
}