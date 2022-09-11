public class Canlilar 
{
   protected void Beslenme()
   {
     Console.WriteLine("Canlilar beslenir.");
   }
   protected void Solunum()
   {
     Console.WriteLine("Canlilar solunum yapar.");
   }  
   protected void Bosaltim()
   {
     Console.WriteLine("Canlilar bosaltim yapar.");
   }


//=>Polymorphism ve Sealed Class;
/*Polymorphism'i saglamak icin metotlar uzerinde 'virtual' keywrod'unu kullaniriz.
Bu keywordun kullanimi ile sanal metotlar olusturuluyor. Bu sanal metotlar, kalitim alinan/miras veren
ust sinif icersinde yazilan ve daha sonra alt siniflar tarafindan yeniden yazilabilen, bicimi degistirilerek
farklilastirilan metotlardir. Yani, ust sinifta virtual anahtar kelimesi ile isaretlenen bir metot, alt sinifta
bicimi degistirilmek uzere 'override' anahtar kelimesi ile yeniden yazilabilir. Mevcut ozelliklerin uzerine de koyulabilir,
tamamen degisiklik de yapilabilir.
*/
/* "sealed" anahtar kelimesi ile bir sinifin baska siniflar tarafindan turetilmesi engellenebilir.
 Yani kalitimi engellemek icin kullanilabilir.
 -> "public sealed class Canlilar{}"
*/
  public virtual void UyaranlaraTepki()
  {
    Console.WriteLine("Canlilar uyaranlara tepki verir.");
  }
}