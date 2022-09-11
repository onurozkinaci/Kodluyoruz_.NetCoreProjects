public class Hayvanlar:Canlilar //Hayvanlar canlidir(kalitim alinir)
{
   protected void Adaptasyon()
   {
     Console.WriteLine("Hayvanlar adaptasyon kurabilir.");
   }

   //'override' keywordu ile 'virtual' ile ust sinifta isaretlenmis olan metot Polymorphism mantigi ile ezilir;
   public override void UyaranlaraTepki()
   {
      base.UyaranlaraTepki(); //metodun ust siniftaki halini calistirir.
      Console.WriteLine("Hayvanlar temasa tepki verir!");
   }
}

//Miras aldirarak artik bu sinifa Hayvanlar sinifinda tanimli ozleliklerin(metot gibi)
//kullanilabilmesi olanagini saglamis oluyorsun. Cunku Surungenler bir Hayvandir ve Adaptasyon kurarlar;
public class Surungenler:Hayvanlar
{
    public Surungenler()
    {
       base.Adaptasyon(); //ust sinifin(parent) protected olan "Adaptasyon" metoduna ulasmak icin "base" keyword'u kullanilir
       base.Beslenme(); //Canlilar class'indaki protected metoda erisim icin
       base.Bosaltim(); //Canlilar class'indaki protected metoda erisim icin
       base.Solunum(); //Canlilar class'indaki protected metoda erisim icin
    }
   public void SurunerekHareketEtmek()
   {
     Console.WriteLine("Surungenler surunerek hareket eder.");
   }
}

public class Kuslar:Hayvanlar
{
    public Kuslar()
    {
      //Nesne olusturuldugunda asagidaki metotlar direkt cagrilacak;
       base.Adaptasyon(); //ust sinifin(parent) protected olan "Adaptasyon" metoduna ulasmak icin "base" keyword'u kullanilir
       base.Beslenme(); //Canlilar class'indaki protected metoda erisim icin
       base.Bosaltim(); //Canlilar class'indaki protected metoda erisim icin
       base.Solunum(); //Canlilar class'indaki protected metoda erisim icin
       base.UyaranlaraTepki(); //polymorphism ile degistirilen metot
    }
   public void Ucmak()
   {
     Console.WriteLine("Kuslar acar.");
   } 
}