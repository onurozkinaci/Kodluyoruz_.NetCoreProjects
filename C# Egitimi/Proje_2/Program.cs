//Proje-2-ToDo Uygulamasi;
using System;
//Varsayilan olarak board'a uc kart eklenecek kisim;
Card card1 = new Card("Task-1","Task-1 tamamlanacak",1,1);
Card card2 = new Card("Task-2","Task-2 tamamlanacak",2,3);
Card card3 = new Card("Task-3","Task-3 tamamlandi",3,2);
ToDoCategory toDoCategory = new ToDoCategory();
DoneCategory doneCategory = new DoneCategory();
Board board = new Board(toDoCategory);
Board board2 = new Board(doneCategory);
board.AddCard(card1);
board.AddCard(card2);
board2.AddCard(card3);
board.ListTheBoard();

//Kullanicinin yapacagi islemler icin olan kisim;
Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
Console.WriteLine("*******************************************");
Console.WriteLine("(1) Board Listelemek");
Console.WriteLine("(2) Board'a Kart Eklemek");
Console.WriteLine("(3) Board'dan Kart Silmek");
Console.WriteLine("(4) Kart Taşımak");

try
{
   int secim = int.Parse(Console.ReadLine());
   //Board board = new Board();

   switch (secim)
   {
    case 1:
         board.ListTheBoard();
         break;
    case 2:
         AddCardToBoard();
         break;
    case 3:
         DeleteCardFromBoard();
         break;
    case 4:
         MoveCard();
         break;
    default:
         break;
   }
}
catch (Exception e)
{
  Console.WriteLine("Hatalı bir seçim yaptınız!");
  Console.WriteLine(e.Message);
}


void AddCardToBoard() //ilk olusturulan card todo kategorisindeki listeye ekleni ve daha sonra bu kart islem gorunce, 
//tamamlaninca diger kategorilere kaydirilabilir.
{
  Console.Write("Başlık Giriniz: ");
  string baslik = Console.ReadLine();
  Console.WriteLine("");
  Console.Write("İçerik Giriniz: ");
  string icerik = Console.ReadLine();
  Console.WriteLine("");
  Console.Write("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5): ");
  int buyukluk = int.Parse(Console.ReadLine());
  Console.WriteLine("");
  Console.Write("Kişi Seçiniz: ");
  int kisiId = int.Parse(Console.ReadLine());
  Console.WriteLine("");
  Card card = new Card(baslik,icerik,buyukluk,kisiId);
  ToDoCategory toDoCategory = new ToDoCategory();
  Board board = new Board(toDoCategory); //referans olarak toDoCategory verilip tum islemler bu class icin gerceklesecek
  board.AddCard(card);
  board.ListTheBoard();
}

void DeleteCardFromBoard()
{
   Console.WriteLine("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.");
   Console.Write("Lütfen kart başlığını yazınız: ");
   string baslik = Console.ReadLine();
   Console.WriteLine();
   IBoardCategory iBoardCategory = KategoriyiBul(baslik);
   //Console.WriteLine(iBoardCategory);
   if(iBoardCategory.KartiBul(baslik) == null)
   {
     Console.WriteLine("Aradığınız kriterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
     Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
     Console.WriteLine("* Yeniden denemek için : (2)");
     int secim = int.Parse(Console.ReadLine());
     if(secim == 1)
        return;
     else //secim ==2 => tekrar denemek icin
        DeleteCardFromBoard();
   }
   else //kart boardda bulunursa
   {
     Board board = new Board(iBoardCategory);
     board.DeleteCard(baslik);
     board.ListTheBoard();
   } 
}

void MoveCard()
{
   Console.WriteLine("Öncelikle taşımak istediğiniz kartı seçmeniz gerekiyor.");
   Console.Write("Lütfen kart başlığını yazınız: ");
   string baslik = Console.ReadLine();
   Console.WriteLine();
   IBoardCategory iBoardCategory = KategoriyiBul(baslik);
   if(iBoardCategory.KartiBul(baslik) == null)
   {
     Console.WriteLine("Aradığınız kriterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
     Console.WriteLine("* İşlemi sonlandırmak için : (1)");
     Console.WriteLine("* Yeniden denemek için : (2)");
     int secim = int.Parse(Console.ReadLine());
     if(secim == 1)
        return;
     else //secim ==2 => tekrar denemek icin
        MoveCard();
   }
   else //kart boardda bulunursa
   {
     Console.WriteLine("Bulunan Kart Bilgileri");
     Console.WriteLine("**************************************");
     Console.WriteLine("Başlık: {0}",baslik);
     Console.WriteLine("Icerik: {0}",iBoardCategory.KartiBul(baslik).Icerik);
     Console.WriteLine("Atanan Kisi: {0}",iBoardCategory.KartiBul(baslik).AtananKisi);
     Console.WriteLine("Buyukluk: {0}",iBoardCategory.KartiBul(baslik).buyukluk);
     //Console.WriteLine("Line: {0}",iBoardCategory.KartiBul(baslik).currentCategory); //kartin guncel bulundugu kategori bilgisi de getirilmeli
     Console.WriteLine("Line: {0}",iBoardCategory.KartiBul(baslik).GetType().Name);
     Console.WriteLine("");
     Console.WriteLine("Lutfen tasimak istediginiz Line'i seciniz:");
     Console.WriteLine("(1) TODO");
     Console.WriteLine("(2) IN PROGRESS");
     Console.WriteLine("(3) DONE");
     int secim = int.Parse(Console.ReadLine());
     Board board = new Board(iBoardCategory);
     if(secim == 1) //TODO
        board.MoveCard(baslik,1,iBoardCategory.KartiBul(baslik));
     else if(secim == 2)
        board.MoveCard(baslik,2,iBoardCategory.KartiBul(baslik));
     else //secim==3
        board.MoveCard(baslik,3,iBoardCategory.KartiBul(baslik));
    board.ListTheBoard();
   } 
}

IBoardCategory KategoriyiBul(string baslik)
{
   IBoardCategory relatedCategory;
   DoneCategory doneCategory = new DoneCategory();
   ToDoCategory toDoCategory = new ToDoCategory();
   InProgressCategory inProgressCategory = new InProgressCategory();

   //Ilgili kart yalnizca bir kategoriye ait olabilecegi icin, degisiklik yapilinca bir oncekinden siliniyor cunku Move() icerisinde;
    if(!(object.Equals(doneCategory.KartiBul(baslik),null)))
        relatedCategory = doneCategory;
    else if(toDoCategory.KartiBul(baslik) != null)
    { relatedCategory = toDoCategory;
      //Console.WriteLine("BULUNDU!!!!!");
    }
    else //InProgressCategory.KartiBul(baslik) != null
        relatedCategory = inProgressCategory;
    return relatedCategory;
}