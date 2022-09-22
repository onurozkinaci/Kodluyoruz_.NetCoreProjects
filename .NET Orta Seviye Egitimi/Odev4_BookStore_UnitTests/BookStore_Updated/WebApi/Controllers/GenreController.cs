using Application.GenreOperations.Queries.GetGenreDetail;
using Application.GenreOperations.Queries.GetGenres;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.Application.BookOperations.Commands.DeleteBook;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using WebApi.Application.BookOperations.Queries.GetBookDetail;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
  [ApiController] //Bu Controllerin Http response donecegini belirttik
  [Route("[controller]s")] //resource'un(controller)request'i nasil karsilayacagi belirtilmis olur, endpointler icin ilk kisim gibi dusun.

  public class GenreController:ControllerBase
  { 
    //own => Controller ozel bir sinif oldugundan, startup.cs altinda service olarak container'a
    //eklenen dbcontext ve automapper servisleri otomatik olarak cozumlenerek burada uygulama baslatildiginda
    //ve endpointe istek gonderildiginde dependency injection yolu ile constructor uzerinden atamasi yapilarak kullanilabilir.
    //**Injectionlar DI Container'dan alinarak cozumlenir;
   
    //private readonly BookStoreDbContext _context;
   //**UT(Unit Test) kapsaminda)-BookStoreDbContext'i direkt degil de interface uzerinden(IBookStoreDbContext) eklemek daha dogru olur, bagimliligi engellemek icin;
     private readonly IBookStoreDbContext _context;

     private readonly IMapper _mapper;

     public GenreController(IBookStoreDbContext context, IMapper mapper)
     {
        _context = context;
        _mapper = mapper;
     }

     [HttpGet]
     public ActionResult GetGenres()
     {
        GetGenresQuery query = new GetGenresQuery(_context, _mapper);
        var obj = query.Handle();
        return Ok(obj);
     }

     [HttpGet("{id}")]
     public ActionResult GetGenreDetail(int id)
     {
        GenreDetailViewModel vm;
        //try
        //{
        GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
        query.GenreId = id;
        GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
        validator.ValidateAndThrow(query);
        vm = query.Handle();
        //}
        /*catch(System.Exception ex)
        {
           return BadRequest(ex.Message);
        }*/  
        return Ok(vm);      
     }

     [HttpPost]
     public IActionResult AddGenre([FromBody] CreateGenreModel newGenre)
     {
        CreateGenreCommand command = new CreateGenreCommand(_context);
        command.Model = newGenre;
        CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
     }

     [HttpPut("id")]
     public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel updatedGenre)
     {
        UpdateGenreCommand command = new UpdateGenreCommand(_context);
        command.GenreId = id;
        command.Model = updatedGenre;
        UpdateGenreCommandValidator validator  = new UpdateGenreCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
     }

     [HttpDelete("id")]
     public IActionResult DeleteGenre(int id)
     {
        DeleteGenreCommand command = new DeleteGenreCommand(_context);
        command.GenreId = id;
        DeleteGenreCommandValidator validator  = new DeleteGenreCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
     }
  }
}