public class Kullanici
{
  private string ad;
  private string soyad;
  private string telNo;
  public string Ad { get => ad; set => ad = value; }
  public string Soyad { get => soyad; set => soyad = value; }
  public string TelNo { get => telNo; set => telNo = value; }

  //Constructor;
  public Kullanici(string ad, string soyad, string telNo)
  {
     this.Ad = ad;
     this.Soyad = soyad;
     this.TelNo = telNo;
  }
  //Overloading the constructor;
  public Kullanici(){}

  public void KullaniciBilgisi()
  {
    Console.WriteLine("isim: "+this.Ad);
    Console.WriteLine("Soyisim: "+this.Soyad);
    Console.WriteLine("Telefon Numarasi: "+this.TelNo);
    Console.WriteLine("-");
  }  
}