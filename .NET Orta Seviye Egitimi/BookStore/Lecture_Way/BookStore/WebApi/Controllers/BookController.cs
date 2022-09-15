
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
  [ApiController] //Bu controllerin Http response donecegini belirttik
  [Route("[controller]s")] //resource'un(controller)request'i nasil karsilayacagi belirtilmis olur, endpointler icin ilk kisim gibi dusun.

  public class BookController:ControllerBase
  {
     //Uygulama calistigi surece verilerin listeden kyabolmamasi adina statik tanimlanir;
     /*Artik static liste yerine db'den veri cekilip db uzerindeki tablo etkileneceginden,
       asagidaki static liste kullanilmayacak;
      private static List<Book> BookList = new List<Book>()
     {
        new Book
        {
          Id = 1,
          Title = "Lean Startup",
          GenreId = 1, //Personal Growth
          PageCount = 200,
          PublishDate = new DateTime(2001,06,12)
        },
        new Book
        {
          Id = 2,
          Title = "Herland",
          GenreId = 2, //Science Fiction
          PageCount = 250,
          PublishDate = new DateTime(2010,05,23)
        },
        new Book
        {
          Id = 3,
          Title = "Dune",
          GenreId = 2, //Science Fiction
          PageCount = 540,
          PublishDate = new DateTime(2001,12,21)
        }
     };
      */

      /**=>Database'e bagli bir yapi olusturmak icin.
       Injection ile bu context'i alip db'ye erisilecek ve uygulama icinde
       bu context degistirilemeyecek(redonly olusturuldu, yalnizca constructor'dan sest edilebilir, asagidaki gibi);
      */
      private readonly BookStoreDbContext _context;
      public BookController(BookStoreDbContext context)
      {
         _context = context;
      }
      
     //-------EndPointler--------;
     //1)Tum kitaplari geri donduren endpoint;
     /*[HttpGet] //Http verb belirteci
     public List<Book> GetBooks()
     {
        //var bookList = BookList.OrderBy(x => x.Id).ToList<Book>(); //id'ye gore order by ile siralanacak listedeki kitaplar
        var bookList = _context.Books.OrderBy(x => x.Id).ToList<Book>();
        return bookList;
     }*/

     //*Refactored GetBooks() which returns ViewModel to end user;
     [HttpGet]
     public IActionResult GetBooks()
     {
        GetBooksQuery query = new GetBooksQuery(_context);
        var result = query.Handle();
        return Ok(result); //basarili sonuc donunce hem 200-OK bilgisi hem de ViewModel birlikte donecek,
        //IActionResult donus tipini verip spesifik bir donus tipi vermemize de gerek kalmiyor.
     }

     //2)id bazinda/parametre alarak kitap donduren endpoint;
    /*[HttpGet("{id}")] //Http verb belirteci
     public Book GetById(int id)
     {
        //var book = BookList.Where(book => book.Id == id).SingleOrDefault();
        var book = _context.Books.Where(book => book.Id == id).SingleOrDefault();
        return book;
     }
     */
     
     //*Refactored HttpGet() which returns ViewModel to end user;
     [HttpGet("{id}")]
     public IActionResult GetById(int id)
     {
        BookDetailViewModel result;
        try
        {
          GetBookDetailQuery query = new GetBookDetailQuery(_context);
          query.BookId = id;
          result = query.Handle();
        }
        catch (Exception ex)
        {
           return BadRequest(ex.Message);
        }
        return Ok(result);
     }

    //3)Parametreyi query bazinda (fromquery ile) alan endpoint;
    /*[HttpGet] //**Http verb belirteci bu sekilde birakilamaz cunku sadece bir tane parametresiz HttpGet attr. kullanilabilir, yukarida bir tane bu sekilde mevcut.
    //Bunun calismasini gormek icin ustteki yoruma alinabilir gecici olarak.
     public Book Get([FromQuery] string id)
     {
        var book = BookList.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
        return book;
     }
     */
     //-----------------------
     //4)Post => body uzerinden parametre gonderilen (yeni kitap olusturmak icin)
     // post endpointi;
     /*[HttpPost]
     public IActionResult AddBook([FromBody] Book newBook)
     {
        //var book = BookList.SingleOrDefault(x => x.Title == newBook.Title);
        var book = _context.Books.SingleOrDefault(x => x.Title == newBook.Title);
        if(book is not null) //"book != null" eklenen kitap onceden listede mevcut ise tekrar eklenmesine izin verme!
           return BadRequest();
        
        //BookList.Add(newBook);
        _context.Books.Add(newBook);
        _context.SaveChanges(); //Artik db'de degisiklik yaptigin icin SaveChanges() de cagrilmali, yalnizca eklemek yeterli degil,
        //kaydetmek de gerekiyor. Add, Update ve Delete icin gerekli, hepsinde db etkilendigi icin!
        return Ok();
     }*/

     //*Refactored AddBook() which takes a model as a parameter from body instead of an entity;
     [HttpPost]
     public IActionResult AddBook([FromBody] CreateBookModel newBook)
     {
        CreateBookCommand command = new CreateBookCommand(_context);
        /*Hata olmasi durumunda CreateBookCommand'den throw ile firlatilan error mesajini
         yakalamak icin kodu try-catch icerisinde yaziyoruz;
        */
        try
        {
          command.Model = newBook;
          command.Handle();
        }
        catch(Exception ex) //Buradan donen Exception mesaji, hata olmasi durumunda CreateBookCommand'den throw ile firlatilan error mesajidir.
        //Hata olursa 400-BadRequest() icerisinde hata olarak dondurulecek.
        {
          return BadRequest(ex.Message);
        }
        return Ok();
     }

    //5)Put => Guncellemenin gerceklestirilecegi id'yi parametre olarak (route'tan alan) 
    //ve guncellenecek alani body uzerinden deger olarak alan Http Put endpointi.
    //Tum bilgileri degil de yalnizca Title gibi belirli bir alan guncellensin istersen, body yerine
    //direkt route uzerinden de parametre gonderebilirsin;
    /*[HttpPut("{id}")] 
     public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
     {
        //var book = BookList.SingleOrDefault(x => x.Id == id);
        var book = _context.Books.SingleOrDefault(x => x.Id == id);
        if(book is null) //guncellenmek istenen kitap, listede mevcut olmali, degilse BadRequest(400) hatasi dondurur.
           return BadRequest();
        
        //Gonderilen id'ye denk olan kitabi, parametre bazinda body olarak iletilen kitap bilgilerinin validasyon kontrolu ile guncelleme;
        book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId; //int deger default yani 0 degilse, bos gonderilmisse(0 olarak) bulunan kitabin kendi degerini kullanacak.
        book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
        book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;
        book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;
        _context.SaveChanges(); //*
        return Ok();
     }
     */

     //*Refactored UpdateBook() which takes a model as a parameter from body instead of an entity;
     [HttpPut("{id}")]
     public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
     {
        try
        {
         UpdateBookCommand command = new UpdateBookCommand(_context);
         /*Hata olmasi durumunda CreateBookCommand'den throw ile firlatilan error mesajini yakalamak icin kod
         try-catch icerisine yazilir;*/
          command.BookId = id;
          command.Model = updatedBook;
          command.Handle();
        }
        catch(Exception ex)
        {
          return BadRequest(ex.Message);
        }
        return Ok();
     }


     
     //6)Delete => Belirtilen kitap kaydini listeden silmeye yarayan endpoint;
     /*[HttpDelete("{id}")]
     public  IActionResult DeleteBook(int id)
     {
         //Parametre olarak verilen id listede mevcutsa, o kitap listeden silinecek/ Validasyon gerekli yani burada da post ve put gibi;
         //var book = BookList.SingleOrDefault(x => x.Id == id);
         var book = _context.Books.SingleOrDefault(x => x.Id == id);
         if(book is null)
            return BadRequest();
         
         //BookList.Remove(book);
         _context.Books.Remove(book);
         _context.SaveChanges(); //*
         return Ok();
     }*/

     //*Refactored DeleteBook();
     [HttpDelete("{id}")]
     public IActionResult DeleteBook(int id)
     {
       try
       {
         DeleteBookCommand command = new DeleteBookCommand(_context);
         command.BookId = id;
         command.Handle();
       }
       catch (Exception ex)
       {
         return BadRequest(ex.Message);
       }
       return Ok();
     }   
  }
  
  
}