using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApi.DbOperations;
using WebApi.Middlewares;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//*To control authentication of user in the project in order to control the requests  by them;
ConfigurationManager configuration = builder.Configuration; 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => 
{
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = configuration["Token:Issuer"],
        ValidAudience = configuration["Token:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"])),
        ClockSkew = TimeSpan.Zero, //server ve host arasindaki olasi saat farkini onemsemeyip token'i es zamanli sonlandiracak,
        //token icin verilen expiration date ile uyumlu calisir.                 
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UniManSystemDbContext>(options => options.UseInMemoryDatabase(databaseName:"UniManDb"));
builder.Services.AddScoped<IUniManSystemDbContext>(provider => provider.GetService<UniManSystemDbContext>());
builder.Services.AddScoped<IUniManSystemDbContext>(provider => provider.GetService<UniManSystemDbContext>());
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); //to use AutoMapper service in project.

builder.Services.AddSingleton<ILoggerService,ConsoleLogger>(); //uygulama baslangicindan bitisine kadar ayni instance uzerinden islem yapilir('singleton service').

var app = builder.Build();
using (var scope = app.Services.CreateScope()) 
{ 
    var services = scope.ServiceProvider; 
    DataGenerator.Initialize(services); 
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication(); //Jwt Bearer Authentication ile saglanan kontrolu algilamasi icin ve bu dogrultuda 
//istek atilmasi sonrasinda response verilmeden authentication ve sonrasinda buan gore authorization kontrolu saglanir.

app.UseHttpsRedirection();

app.UseAuthorization();

//Custom exception middleware that we defined => endpointler calismadan once verilir.
//'await next' ile MapControllers middleware'i calisip response doner ve bunun uzerinden donen sonuca gore
//CustomExceptionMiddleware da islemlerini gerceklestirir/tamamlar.
app.UseCustomException();

app.MapControllers();

app.Run();
