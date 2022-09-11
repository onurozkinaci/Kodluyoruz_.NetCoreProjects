using System.Collections.Generic;
public class TelefonRehberi
{
   //static olunca bir kez calistigindan TelefonRehberi'nin farkli farkli instancelari alindiginda
   //kayitli kullanicilar runtime esnasinda surekli sifirlanmaz;
   private static List<Kullanici> kullanicilar = new List<Kullanici>();

   public void YeniNumaraKaydet(Kullanici kullanici) //telefon rehberine kullanici eklemek
   {
      kullanicilar.Add(kullanici); 
      Console.WriteLine("Telefon numarasi basariyla eklendi!");
   }
   public bool TelefonNumarasiSil(string isim) //gonderilen ad veya soyada gore bulunan kullaniciyi silmek
   {
      bool flag=false;
      Kullanici arananKullanici = new Kullanici();
      for (int i=0; i<kullanicilar.Count;i++)
      {
        if(kullanicilar[i].Ad == isim || kullanicilar[i].Soyad == isim)
        {
            arananKullanici = kullanicilar[i];
            flag=true;
            break;
        }
      }
      kullanicilar.Remove(arananKullanici); 
      //Console.WriteLine("Kullanici basairyla eklendi!");
      return flag; //false ise kullanici bulunamadi ve silinemedi demektir.
   }

   public bool TelefonNumarasiGuncelle(string isim, string telNo)
   {
      bool flag = false;
      for (int i=0; i<kullanicilar.Count;i++)
      {
        if(kullanicilar[i].Ad == isim || kullanicilar[i].Soyad == isim)
        {
            kullanicilar[i].TelNo = telNo; //aranan kullanicinin telefon numarasi guncellenir.
            //Console.WriteLine("Kullanicinin telefon numarasi basariyla guncellendi");
            flag=true;
            break;           
        }
      }
      return flag; //false ise kullanici bulunamadi ve guncellenemedi demektir.
   }

   public void RehberiListele()
   {
     Console.WriteLine("Telefon Rehberi");
     Console.WriteLine("*********************************");
     for(int i =0; i<kullanicilar.Count; i++)
        kullanicilar[i].KullaniciBilgisi();
   }

   public bool IsimIleArama(string isim)
   {
      bool flag = false;
      Console.WriteLine("Arama Sonuclariniz:");
      Console.WriteLine("*********************************");
      for (int i=0; i<kullanicilar.Count;i++)
      {
        if(kullanicilar[i].Ad == isim || kullanicilar[i].Soyad == isim)
        {
          kullanicilar[i].KullaniciBilgisi();
          flag=true;
          break;           
        }
      }
      return flag;
   }
   public void TelefonNumarasiIleArama(string telNo)
   {
      Console.WriteLine("Arama Sonuclariniz:");
      Console.WriteLine("*********************************");
      for (int i=0; i<kullanicilar.Count;i++)
      {
        if(kullanicilar[i].TelNo == telNo)
        {
          kullanicilar[i].KullaniciBilgisi();
          break;           
        }
      }
   }
}