Console.WriteLine("Calisan Sayisi: {0}", Calisan.CalisanSayisi); //static ve public olan CalisanSayisi direkt sinif ismi uzerinden, instance olusturulmadan cagrilabilir.
//Static olmayan fieldlari setlemek-deger atamak icin instance alinir;
Calisan calisan = new Calisan("Ayse","Yilmaz","IK");
Console.WriteLine("Calisan Sayisi: {0}", Calisan.CalisanSayisi);

/*Statik sinif old. instance alinamaz;
Islemler islemler = new Islemler(); => hata verir */
Console.WriteLine("Toplama islemi sonucu: {0}", Islemler.Topla(100,200));
Console.WriteLine("Cikarma islemi sonucu: {0}", Islemler.Cikar(400,50));

//Static Sinif(Class) ve Uyeleri;
/*Bir sinifin static olmayan field,metot ve ozelliklere/property
o siniftan olusturulan nesne araciligi ile erisilirken, 
static olan elemanlara ise o sinifin adi uzerinden erisilir, nesne olusturmaya gerek yoktur.
=> Static constructor yalnizca bir defa calisir, sonrasinda baska bir constructor uzerinden parametre atamasi yapiliyorsa
o constructor uzerinden islem devam eder fakat static constructor instance alinirken tekrar cagrilmaz, yalnizca bir kez en basta calisir.
=> Static class icerisindeki tum elemanlar static olmak zorundadir!
=> Static siniflardan kalitim(inheritance) islemi de uygulanamaz!
*/
class Calisan
{
  private static int calisanSayisi;
  
  public static int CalisanSayisi {get => calisanSayisi;}

  private string isim;
  private string soyIsim;
  private string departman;

  //static constructor => erisim belirteci(public gibi) yoktur;
  static Calisan()
  {
    calisanSayisi = 0;

  }
  public Calisan(string isim, string soyIsim, string departman)
  {
    this.isim = isim;
    this.soyIsim = soyIsim;
    this.departman = departman;
    calisanSayisi++; //her eklemede 1 artacak
  }

}

static class Islemler
{
    public static long Topla(int sayi1,int sayi2)
    {
       return sayi1+sayi2;  
    }
    public static long Cikar(int sayi1,int sayi2)
    {
       return sayi1-sayi2;  
    }
}


