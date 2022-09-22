using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.Application.BookOperations.Commands.DeleteBook;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using WebApi.Application.BookOperations.Queries.GetBookDetail;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
  [ApiController] //Bu Controllerin Http response donecegini belirttik
  [Route("[controller]s")] //resource'un(controller)request'i nasil karsilayacagi belirtilmis olur, endpointler icin ilk kisim gibi dusun.

  public class BookController:ControllerBase
  {
      /**=>Database'e bagli bir yapi olusturmak icin.
       Injection ile bu context'i alip db'ye erisilecek ve uygulama icinde
       bu context degistirilemeyecek(redonly olusturuldu, yalnizca constructor'dan sest edilebilir, asagidaki gibi);
      */
      
      //private readonly BookStoreDbContext _context;
      //**UT(Unit Test) kapsaminda)-BookStoreDbContext'i direkt degil de interface uzerinden eklemek daha dogru olur, bagimlilik kapsaminda;
      private readonly IBookStoreDbContext _context;
      
      private readonly IMapper _mapper; //dependency injection package'ini da implemente ettigimiz icin dep. injection kullanilabilir.
      
      public BookController(IBookStoreDbContext context, IMapper mapper)
      {
         _context = context;
         _mapper = mapper;
      }
      
     //-------EndPointler--------;
     //1)Tum kitaplari geri donduren endpoint;
     //*Refactored GetBooks() which returns ViewModel to end user;
     [HttpGet]
     public IActionResult GetBooks()
     {
        GetBooksQuery query = new GetBooksQuery(_context,_mapper);
        var result = query.Handle();
        return Ok(result); //basarili sonuc donunce hem 200-OK bilgisi hem de ViewModel birlikte donecek,
        //IActionResult donus tipini verip spesifik bir donus tipi vermemize de gerek kalmiyor.
     }

     //2)id bazinda/parametre alarak kitap donduren endpoint;
     //*Refactored HttpGet() which returns ViewModel to end user;
     [HttpGet("{id}")]
     public IActionResult GetById(int id)
     {
        BookDetailViewModel result;
        GetBookDetailQuery query = new GetBookDetailQuery(_context,_mapper); //*refactor-AutoMapper eklendi
        query.BookId = id;
        //FluentValidation ile validation kontrolu yapilir;
        GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
        validator.ValidateAndThrow(query); //**Throws an error if there is a problem and it will be catched with the written try-catch block codes in the CustomExceptionMiddleware.cs file.
        //There is no need to write try-catch here anymore to catch the thrown message by ValidateAndThrow, so there is no need to write try-catch here anymore.
        result = query.Handle();
        return Ok(result);
     }

     //4)Post => body uzerinden parametre gonderilen (yeni kitap olusturmak icin)
     //*Refactored AddBook() which takes a model as a parameter from body instead of an entity;
     [HttpPost]
     public IActionResult AddBook([FromBody] CreateBookModel newBook)
     {
        CreateBookCommand command = new CreateBookCommand(_context,_mapper); //bir onceki adima gore tekrar refactor edilip automapper eklendi.
        command.Model = newBook; 
        CreateBookCommandValidator validator = new CreateBookCommandValidator();
        validator.ValidateAndThrow(command); //hata firlatirsa middleware class'indaki kontrollerle middleware'da yakalanacak(CustomExceptionMiddleware),hata vermezse islem yapip OK donecek. 
        //Middleware'da try-catch ile buradan firlatilan hata yakalaniyor.
        command.Handle();
        return Ok();
     }

    //5)Put => Guncellemenin gerceklestirilecegi id'yi parametre olarak (route'tan alan) 
    //*Refactored UpdateBook() which takes a model as a parameter from body instead of an entity;
     [HttpPut("{id}")]
     public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
     {
          UpdateBookCommand command = new UpdateBookCommand(_context,_mapper); //*Refactored => _mapper added to use AutoMapper.
         /*Hata olmasi durumunda CreateBookCommand'den throw ile firlatilan error mesajini yakalamak icin kod
         try-catch icerisine yazilir;*/
          command.BookId = id;
          command.Model = updatedBook;
          //FluentValidation ile validation kontrolu yapilir;
          UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
          validator.ValidateAndThrow(command); //**Throws an error if there is a problem and it will be catched with the written try-catch block codes in the CustomExceptionMiddleware.cs file.
          //There is no need to write try-catch here anymore to catch the thrown message by ValidateAndThrow or the thrown error message if there is no book with the sent id in the database acc. to the
          //control on the UpdateBookCommand class!
          command.Handle();
          return Ok();
     }

     //6)Delete => Belirtilen kitap kaydini listeden silmeye yarayan endpoint;
     //*Refactored DeleteBook();
     [HttpDelete("{id}")]
     public IActionResult DeleteBook(int id)
     {
         DeleteBookCommand command = new DeleteBookCommand(_context);
         command.BookId = id;
         //BookId setlendikten sonra 'fluent validor' ile verdigimiz validasyon kontrolu yapilir;
         DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
         validator.ValidateAndThrow(command); //hata alirsa catch'e duser ve exception/hata verir.
         //Artik burada try-catch vermene gerek yok, bu validation hata firlatirsa "CustomExceptionMiddleware.cs" class'inda
         //yazdigimiz try-catch bloklarindaki kod ile bu hata yakalanacak.
         command.Handle(); //ustteki kod catch'e dusmezse bu calisir ve sorunsuz bir sekilde delete islemi gerceklesir
         return Ok();
     }   
     
  }
  
  
}