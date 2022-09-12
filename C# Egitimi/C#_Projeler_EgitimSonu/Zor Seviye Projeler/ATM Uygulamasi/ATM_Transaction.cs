public class ATM_Transaction
{
   private static Dictionary<string,double> kullaniciHesaplari = new Dictionary<string, double>(); //kullanicilarin hesaplarindaki bakiye miktarlarini tutmak icin
   private double guncelBakiye;
   public double GuncelBakiye { get => guncelBakiye; set => guncelBakiye = value; }

   public ATM_Transaction(double guncelBakiye)
   {
     this.guncelBakiye = guncelBakiye;
   }
   public ATM_Transaction(){}

   public bool ParaCekme(string id, double miktar)
   { 
      bool flag = false;
      if(kullaniciHesaplari.ContainsKey(id))
      {
         foreach (var account in kullaniciHesaplari.Keys)
         {
           if(account == id && !(kullaniciHesaplari[account] <=0))
           {
             kullaniciHesaplari[account] -= miktar;
             Console.WriteLine("Hesabinizdan {0} TL cekilmistir.",miktar);
             flag = true;
             break;
           }
           else if(account == id && kullaniciHesaplari[account] <=0)
           {
             Console.WriteLine("Su anda bakiyeniz para cekmek icin yetersiz, oncelikle hesabiniza para yatirmalisiniz!");
             break;
           }
         }
      }
      else
         Console.WriteLine("Kullanici hesabi icin bakiye kaydi mevcut degil!");
      return flag;
   }

   public bool ParaYatirma(string id, double miktar)
   {
      bool flag = true;
      if(kullaniciHesaplari.ContainsKey(id))
      {
         foreach (var account in kullaniciHesaplari.Keys)
         {
           if(account == id && !(kullaniciHesaplari[account] <=0))
           {
             kullaniciHesaplari[account] += miktar;
             Console.WriteLine("Hesabiniza {0} TL eklenmistir.",miktar);
             flag = true;
             break;
           }
         }
      }
      else //kullanici icin yeni bakiye hesabi ac
      {
         Console.WriteLine("Kullanici icin yeni bakiye hesabi acildi!");
         kullaniciHesaplari[id] = miktar;
         flag = true;
      }
      return flag;
   }

   public bool OdemeYapma(double miktar, string gonderenId, string aliciId)
   {
      bool flag = false;
      if(kullaniciHesaplari.ContainsKey(aliciId))
      {
        foreach (var accountReceiver in kullaniciHesaplari.Keys)
        {
          if(accountReceiver == aliciId)
          {
            kullaniciHesaplari[accountReceiver] += miktar;
            break;
          }
        }
        if(kullaniciHesaplari.ContainsKey(gonderenId))
        {
          foreach (var accountSender in kullaniciHesaplari.Keys)
          {
             if(accountSender == gonderenId && !(kullaniciHesaplari[accountSender] <=0))
             {
               kullaniciHesaplari[accountSender] -= miktar;
               flag=true;
               break;
             }
          }
        }
      }
      else
         Console.WriteLine("Odeme yapilacak kullanici hesabi bulunamadi");
      return flag;
   }

   public void HesapEkle(User user,double guncelBakiye)
   {
      if(kullaniciHesaplari.ContainsKey(user.Id))
         Console.WriteLine("Bu kullanici hesabi mevcut!");
      else
         kullaniciHesaplari.Add(user.Id,guncelBakiye);
   }
   public void GunSonuAl()
   {
      Console.WriteLine("-----------Gun Sonu Raporu----------------");
      string date = DateTime.Now.ToString("ddMMyyyy");
      string fileName = date + ".txt";
      StreamReader sr = new StreamReader(fileName);
      while(sr.ReadLine() is string s) //bos olmayan satiri dosyadan okuyup gecici(temporary) s variable'ina atar.
          Console.WriteLine(s);
      //string s = sr.ReadToEnd(); //ustteki dongu ile ayni islemi yapip dosya icerisindeki tum verileri degiskene aktarir.
      //Console.WriteLine(s);
      sr.Close();
      Console.WriteLine("-------------------------------------------");
   }
}
