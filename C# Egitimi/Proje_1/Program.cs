//Telefon Rehberi Uygulamasi;
using System;
//=>TelefonRehberi class;inda kullanicilari static tanimladigin icin
//bu class'in farkli instancelari alinsa bile static deger bir kez calistigi icin
//ayni liste degeri tutulmus olacak, devamli sifirdan liste olusturulmayacak.

//Manuel olarak 5 kisinin rehbere eklenmesi;
Kullanici kullanici1 = new Kullanici("Onur","Ozk","05599999999");
Kullanici kullanici2 = new Kullanici("Deniz","Degirmen","05588888888");
Kullanici kullanici3 = new Kullanici("Volkan","Halepli","05577777777");
Kullanici kullanici4 = new Kullanici("Elif","Kolacan","05566666666");
Kullanici kullanici5 = new Kullanici("Gamze","Surmen","05555555555");
TelefonRehberi telRehberi = new TelefonRehberi();
telRehberi.YeniNumaraKaydet(kullanici1);
telRehberi.YeniNumaraKaydet(kullanici2);
telRehberi.YeniNumaraKaydet(kullanici3);
telRehberi.YeniNumaraKaydet(kullanici4);
telRehberi.YeniNumaraKaydet(kullanici5);
telRehberi.RehberiListele();

//Kullanicidan bilgi/input alinarak gerceklestirilen islemler;
Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
Console.WriteLine("(1) Yeni Numara Kaydetmek");
Console.WriteLine("(2) Varolan Numarayı Silmek");
Console.WriteLine("(3) Varolan Numarayı Güncelleme");
Console.WriteLine("(4) Rehberi Listelemek");
Console.WriteLine("(5) Rehberde Arama Yapmak");

try
{
   int secim = int.Parse(Console.ReadLine());
   switch (secim)
   {
     case 1:
         YeniNumaraKaydetmek();
         break;
     case 2:
         NumaraSilmek();
         break;
     case 3:
         NumaraGuncelleme();
         break;
    case 4:
         telRehberi.RehberiListele();
         break;
    case 5:
         RehberdeAramaYap();
         break;
    default:
        break;        
   }
}
catch (Exception e)
{
   Console.WriteLine(e.Message);
}


static void YeniNumaraKaydetmek()
{
  Console.Write("Lutfen isim giriniz: ");
  string isim = Console.ReadLine();
  Console.WriteLine();
  Console.Write("Lutfen soyisim giriniz: ");
  string soyad = Console.ReadLine();
  Console.WriteLine();
  Console.Write("Lutfen telefon numarasi giriniz: ");
  string telNo = Console.ReadLine();
  Console.WriteLine();
  Kullanici kullanici = new Kullanici(isim,soyad,telNo);
  TelefonRehberi telefonRehberi = new TelefonRehberi();
  //metotlari static yapmazsan direkt yukarida tanimlanan "telRehberi" ne ekleme
  //yapip yeni instance almadan da islem yapabilirsin ama liste TelefonRehberi class'inda static olarak
  //tanimlandigindan bir kez calisir ve yeniden instance alinsa bile icerisindeki eski veri kaybolmaz, sifirlanmadigi
  //icin constructorda;
  telefonRehberi.YeniNumaraKaydet(kullanici);
  telefonRehberi.RehberiListele();
}

static void NumaraSilmek()
{
  Console.Write("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz: ");
  string isim = Console.ReadLine();
  Console.WriteLine();
  TelefonRehberi telefonRehberi = new TelefonRehberi();
  if(telefonRehberi.IsimIleArama(isim) == false)
  {  Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
     Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
     Console.WriteLine("* Yeniden denemek için      : (2)");
     int secim = int.Parse(Console.ReadLine());
     if(secim == 1)
        return;
     else //secim ==2
        NumaraSilmek(); //tekrar denemek icin
  }
  else //if TelefonNumarasiSil() returns the searched user
  {
    Console.WriteLine("{0} isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n)",isim);
    string onay = Console.ReadLine();
    if(onay == "y")
       telefonRehberi.TelefonNumarasiSil(isim);
    else
       return;
  }
  telefonRehberi.RehberiListele();
 }

static void NumaraGuncelleme()
{
  Console.Write("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz: ");
  string input = Console.ReadLine();
  Console.WriteLine();
  TelefonRehberi telefonRehberi = new TelefonRehberi();
  if(telefonRehberi.IsimIleArama(input) == false)
  {
     Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
     Console.WriteLine("* Güncellemeyi sonlandırmak için    : (1)");
     Console.WriteLine("* Yeniden denemek için              : (2)");
     int secim = int.Parse(Console.ReadLine());
     if(secim == 1)
        return;
     else //secim ==2
        NumaraGuncelleme(); //tekrar denemek icin
  }
  else //rehberde uygun veri bulunursa
  {
    Console.Write("Guncel telefon numarasi giriniz: ");
    string telNo = Console.ReadLine();
    telefonRehberi.TelefonNumarasiGuncelle(input,telNo);
  }
  telefonRehberi.RehberiListele();
}

static void RehberdeAramaYap()
{
  TelefonRehberi telefonRehberi = new TelefonRehberi();
  Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
  Console.WriteLine("*********************************");
  Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1)");
  Console.WriteLine("Telefon numarasına göre arama yapmak için: (2)");
  int secim = int.Parse(Console.ReadLine());
  if(secim == 1)
  {
    Console.Write("Hangi isme gore arama yapmak istiyorsunuz? ");
    string isim = Console.ReadLine();
    Console.WriteLine();
    telefonRehberi.IsimIleArama(isim);
  }
  else //secim ==2
  {
    Console.Write("Hangi telefon numarasina gore arama yapmak istiyorsunuz? ");
    string telNo = Console.ReadLine();
    Console.WriteLine();
    telefonRehberi.TelefonNumarasiIleArama(telNo);
  }
}
