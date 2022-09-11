using System;
//Try-Catch-Finally;
/*Runtime hatalarini handle etmek icin kullanilan bir yapidir, compile hatalari zaten daha kod yazarken goruldugu icin
hataya anlik olarak mudahale etmek mumkundur.
Try catch blokları sayesinde uygulama içerisinde bir hata oluştuğunda belirtilen işlemler yaptırılabilir.
[try{ Hataya sebebiyet verme ihtimali olan kod }
catch { Hata ile karşılaşıldığında ne yapılacağı buraya yazılır }
finally{ Hata olsun olmasın mutlaka yapılmasını istediğimiz işler varsa buraya yazarız }
]
*/
/*
try
{
  Console.WriteLine("Bir sayi giriniz:");
  int sayi = Convert.ToInt32(Console.ReadLine());
  Console.WriteLine("Girilen sayi: " + sayi);  
}
catch (Exception ex)
{
  Console.WriteLine(ex.Message);
}
// finally
// {
//   Console.Write("Islem tamamlandi...");
// }
*/

//Ozel Exception tipleri uzerinden hatalari yakalayip bu dogrultuda ozellestirilmis mesajlar vermek icin;
try
{
  //int a = int.Parse(null); =>ArgumentNullException firlatir
  //int a = int.Parse("test"); =>FormatException firlatir
  int a = int.Parse("-20000000000"); //=>OverflowException firlatir, girilen deger int kapsaminin(min-max degerlerinin) disinda old. icin
}
/*
=>Ozellestirilmis exception tiplerinden once Exception'i verirsen ozellestirilmis olanlar compile hatasi verir cunku
bu Exception hepsini kapsadigindan digerlerine ugramayacagi icin yazilmalarina gerek kalmaz. Ozellestirilen exception tiplerinden sonra
Genel Exception'i vermek en dogrusudur, hicbirine girmezse onun icerisindekileri calistirir;
catch (Exception ex)
{
  Console.WriteLine("Genel hata!");
  Console.WriteLine(ex);
}
*/

catch (ArgumentNullException ex)
{
  Console.WriteLine("Bos deger girdiniz!");
  Console.WriteLine(ex);
}
catch (FormatException ex)
{
  Console.WriteLine("Veri tipi uygun degil!");
  Console.WriteLine(ex);
}
//OverflowException => Girilen degerin veri tipine gore max veya min degerlerinin disinda olmasi;
catch (OverflowException ex)
{
  Console.WriteLine("Cok kucuk ya da cok buyuk bir deger girdiniz!");
  Console.WriteLine(ex);
}
/*catch (Exception ex)
{
  Console.WriteLine("Genel hata!");
  Console.WriteLine(ex);
}*/
finally //hata alinsa da en son calisir
{
   Console.WriteLine("Islem basariyla tamamlandi..."); 
}



