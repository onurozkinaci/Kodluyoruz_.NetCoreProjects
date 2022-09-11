using System;
/*
class SinifAdi
{
  [Erisim Belirleyici][Veri Tipi] OzellikAdi;
  [Erisim Belirleyici][Geri Donus Tipi] MetotAdi([Parametre Listesi]);
  {
    //Metot komutlari
  }
}
*/

/* =>Erisim Belirleyiciler(Access Modifiers);
Public => Her yerden erisilebilir
Private => Sadece tanimlandigi sinif icerisinde erisilebilir
Internal => Sadece kendi bulundugu proje icerisinde erisilebilir
Protected => Sadece tanimlandigi sinifta veya o siniftan miras(kalitim) alan siniflarda kullanilabilir.
*/

//Calisan sinifindan bir instance(ornek) yaratiyoruz ve bu nesneler araciligiyla
//class'in propertylerine ve metotlarina erisiyoruz;

/*Calisan calisan1 = new Calisan(); //instance
calisan1.Ad = "Ayse";
calisan1.Soyad = "Kara";
calisan1.No = 2342352;
calisan1.Departman = "Insan Kaynaklari";
calisan1.CalisanBilgileri(); //ekrana yazdirmak icin
Console.WriteLine("----------------------");
*/
//=>Constructora parametre gondererek ustteki instance'i olusturmak icin;
Calisan calisan1 = new Calisan("Ayse","Kara",2342352,"Insan Kaynaklari");
calisan1.CalisanBilgileri();
Console.WriteLine("----------------------");

/*Calisan calisan2 = new Calisan();//instance
calisan2.Ad = "Deniz";
calisan2.Soyad = "Arda";
calisan2.No = 1254656;
calisan2.Departman = "Satin Alma";
calisan2.CalisanBilgileri(); //ekrana yazdirmak icin
*/
//=>Constructora parametre gondererek ustteki instance'i olusturmak icin
Calisan calisan2 = new Calisan("Deniz","Arda",1254656,"Satin Alma");
calisan1.CalisanBilgileri();
Console.WriteLine("----------------------");

Calisan calisan3 = new Calisan("Onur","Ozk");
calisan3.No = 2345678;
calisan3.Departman = "Bilgi Teknolojileri";
calisan3.CalisanBilgileri();
Console.WriteLine("----------------------");


class Calisan 
{
   //Propertyler-Ozellikler-bu class'i tanimlayan seyler;
   public string Ad;
   public string Soyad;
   public int No; //employee number
   public string Departman;

   //Constructor;
   public Calisan(string ad, string soyad, int no, string departman)
   {
      this.Ad = ad;
      this.Soyad = soyad;
      this.No = no;
      this.Departman = departman;
   }

   //Overloading the constructor;
   public Calisan(string ad,string soyad)
   {
      this.Ad = ad;
      this.Soyad = soyad;
   }

   //Overloading the constructor(default one);
   public Calisan(){}

   
   public void CalisanBilgileri()
   {
     Console.WriteLine("Calisanin Adi: {0}",Ad);
     Console.WriteLine("Calisanin Soyadi: {0}",Soyad);
     Console.WriteLine("Calisanin Numarasi: {0}",No);
     Console.WriteLine("Calisanin Departman: {0}",Departman);
   } 
}


/* =>Kurucu Metotlar(Constructor);
-Bir sinifin nesnesi olusturuldugunda(new ile instance olusturuldugunda) arka planda
otomatik olarak calistirilan metotlardir. 
-Erisim belirleyicileri public omak zorundadir ve geri donus tipleri yoktur, yazilmaz.
-Class ismi ile ayni isimde olmak zorundadir.
-Overloading mantigi ile birden cok constructor tanimlayip instance olustururken farkli farkli parametreler
gondererek veya parametre gondermeden constructorlari ayri amaclarla kullanabilirsin.
-Parametre almayan constructor(default)'i baska bir constructor tanimlamadiysan belirtmene gerek yok cunku bu
class'tan instance alinca otomatik,default olarak cagriliyor. Baska bir constructor belirttiysen bunu da ayrica belirtmen
gerekiyor ama, artik otomatik cagrilmiyor. 
*/

