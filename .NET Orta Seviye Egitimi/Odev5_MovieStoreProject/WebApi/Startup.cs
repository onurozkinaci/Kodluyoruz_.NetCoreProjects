using System;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WebApi.DbOperations;
using WebApi.Middlewares;
using WebApi.Services;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Controllerlari servis olarak eklemeden hemen once JWT kutuphanesi altindan eklemis oldugumuz Bearer Token
            //servisine ait eklenmesi gereken bilgileri asagidaki gibi belirtiyoruz;
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => 
            {
                /**JWT-Bearer authentication servisini eklerken Configuration altinda verilen SecurityKey gibi
                  ozelliklerini atamak adina 'appsettings.json' icerisinde "Token" nesnesini tanimladik;
                */
                //Token'in nasil valide edilecegini belirtmek icin;
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                   ValidateAudience = true,
                   ValidateIssuer = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = Configuration["Token:Issuer"],
                   ValidAudience = Configuration["Token:Audience"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"])),
                   ClockSkew = TimeSpan.Zero, //server ve host arasindaki olasi saat farkini onemsemeyip token'i es zamanli sonlandiracak,
                   //token icin verilen expiration date ile uyumlu calisir.                 
                };
            });
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });
            services.AddDbContext<MovieStoreDbContext>(options => options.UseInMemoryDatabase(databaseName:"MovieStoreDb"));
            services.AddScoped<IMovieStoreDbContext>(provider => provider.GetService<MovieStoreDbContext>());

            services.AddAutoMapper(Assembly.GetExecutingAssembly()); //to use AutoMapper service in project after installing the automapper packages on terminal.

            //*Dependency injection uygulanacak classlarimizi ve bagimliliklarini otomatik olusturulan container'a ('IServiceCollection') eklemek icin;
            services.AddSingleton<ILoggerService,ConsoleLogger>(); //uygulama baslangicindan bitisine kadar ayni instance uzerinden islem yapilir('singleton service').
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            }

            app.UseAuthentication(); //*Authentication olmadan authorization olmaz, yetkilendirilebilmesi icin oncelikle istek gonderecek kullanicinin
            //kimligi belirlenmeli ve sonrasinda routing-authorization ve endpointe ait middlewarelar kullanilmali.

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //Custom exception middleware that we defined => endpointler calismadan once verdik;
            app.UseCustomException();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
