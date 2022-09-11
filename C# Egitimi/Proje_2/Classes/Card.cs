using System.Collections.Generic;

public class Card
{
   
   public static Dictionary<int,string> takimUyeleri = new Dictionary<int, string>
   {
     {1, "Ali Demir"}, 
     {2, "Deniz Solar"},
     {3,"Ayse Dumen"},
     {4,"Duru Koruyan"}
   };
   
   private string baslik;
   private string currentCategory;
   private string icerik;
   private string atananKisi; //takim uyesinin adi-soyadi
   public Buyukluk buyukluk; //kullanicidan int olarak alinip enum tipine(Buyukluk) cevrilir constructordaki kontrolle
   public string Baslik { get => baslik; set => baslik = value; }
   public string Icerik { get => icerik; set => icerik = value; }
   public string AtananKisi { get => atananKisi; set => atananKisi = value; } //constructor'da kullanicidan int olarak alinip dictionary'deki ad-soyad(string) karsiligi dondurulur.
   public Card(String baslik,String icerik,int buyukluk,int atananKisi)
   {
      this.Baslik = baslik;
      this.Icerik = icerik;
      switch(buyukluk)
      {
        case 1:
            this.buyukluk = Buyukluk.XS;
            break;
        case 2:
            this.buyukluk = Buyukluk.S;
            break;
        case 3:
            this.buyukluk = Buyukluk.M;
            break;
        case 4:
            this.buyukluk = Buyukluk.L;
            break;
        case 5:
            this.buyukluk = Buyukluk.XL;
            break;
        default:
            break;
      } 
      this.AtananKisi = FindTheTeamMember(atananKisi);
   }
   public Card(){}

   public string FindTheTeamMember(int atananId)
   {
      if(atananId != 0)
      {
        string bulunanUye = "";
        foreach(var item in takimUyeleri)
        {
            if(item.Key == atananId)
                bulunanUye = item.Value;
        }
        return bulunanUye;
      }
      else
      {
         Console.WriteLine("Hatali girisler yaptiniz!");
         return "Mevcut olmayan uye";
      }
   }
}

public enum Buyukluk
{
    XS = 1,S,M,L,XL
}
