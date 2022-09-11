public class Bitkiler:Canlilar //Bitkiler canlidir(kalitim alinir)
{
    //sadece kendisinden kalitim alan siniflardan erisilebilmesi icin(protected);
   protected void Fotosentez()
   {
     Console.WriteLine("Bitkiler fotosentez yapar.");
   }  

   //'override' keywordu ile 'virtual' ile ust sinifta isaretlenmis olan metot Polymorphism mantigi ile ezilir;
   public override void UyaranlaraTepki()
   {
      //base.UyaranlaraTepki(); //metodun ust siniftaki halini calistirir.
      Console.WriteLine("Bitkiler gunese tepki verir!");
   }
}

//Miras aldirarak artik bu sinifa Bitkiler sinifinda tanimli ozleliklerin(metot gibi)
//kullanilabilmesi olanagini saglamis oluyorsun. Cunku TohumluBitkiler bir bitkidir ve fotosentez yaparlar;
public class TohumluBitkiler:Bitkiler
{
    public TohumluBitkiler()
    {
       base.Fotosentez(); //"base" ile kalitim alinan ust sinifin metotlarina erisilebilir ve Bitkiler sinifinda protected erisim seviyesinde olan
       //Fotosentez metoduna TohumluBitkiler sinifindan olusturulan bir instance(nesne) uzerinden erisebilmek icin constructor icerisinde bu "base" keyword'u 
       //kullanilarak nesne olusturuldugunda bu metoda erisim yetkisi verilmis olur.
       base.Beslenme(); //Canlilar class'indaki protected metoda erisim icin
       base.Bosaltim(); //Canlilar class'indaki protected metoda erisim icin
       base.Solunum(); //Canlilar class'indaki protected metoda erisim icin
       base.UyaranlaraTepki(); //polymorphism ile degistirilen metot
    }
    public void TohumlaCogalma()
    {
     Console.WriteLine("Tohumlu bitkiler tohumla cogalir.");   
    }
}

public class TohumsuzBitkiler:Bitkiler
{
    public TohumsuzBitkiler()
    {
       base.Fotosentez(); //"base" ile kalitim alinan ust sinifin metotlarina erisilebilir ve Bitkiler sinifinda protected erisim seviyesinde olan
       //Fotosentez metoduna TohumluBitkiler sinifindan olusturulan bir instance(nesne) uzerinden erisebilmek icin constructor icerisinde bu "base" keyword'u 
       //kullanilarak nesne olusturuldugunda bu metotlar direkt cagirlacak, nesne uzerinden yine cagrilip ayrica(bitki.Fotosentez() gibi) calistirilamazlar! ;
       base.Beslenme(); //Canlilar class'indaki protected metoda erisim icin
       base.Bosaltim(); //Canlilar class'indaki protected metoda erisim icin
       base.Solunum(); //Canlilar class'indaki protected metoda erisim icin
    }
    public void SporlaCogalma()
    {
      Console.WriteLine("Tohumsuz bitkiler sporla cogalir.");   
    }
}