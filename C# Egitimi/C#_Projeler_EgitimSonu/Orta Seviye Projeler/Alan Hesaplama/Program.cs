//C# Ile Alan Hesaplama Projesi;
Console.WriteLine("Islem yapmak istediginiz sekli seciniz.");
Console.WriteLine("(1)Kare");
Console.WriteLine("(2)Daire");
Console.WriteLine("(3)Ucgen");
try
{
  int secim = int.Parse (Console.ReadLine());
  switch (secim)
  {
   case 1:
        Console.Write("Kenar icin deger giriniz: ");
        int kenar = int.Parse(Console.ReadLine());
        Console.Write("Yukseklik icin deger giriniz: "); //hacim hesabi yapilmak istenirse
        int yukseklik = int.Parse(Console.ReadLine());
        Kare kare = new Kare(kenar);
        kare.Yukseklik = yukseklik;
        IslemSecenekleri(kare);
        break;
   case 2:
        Console.Write("Yaricap icin deger giriniz: ");
        int yaricap = int.Parse(Console.ReadLine());
        Daire daire = new Daire(yaricap);
        IslemSecenekleri(daire);
        break;
   case 3:
        Console.Write("Taban uzunlugu giriniz: ");
        int tabanUzunlugu = int.Parse(Console.ReadLine());
        Console.Write("Yukseklik giriniz: ");
        int ucgenYukseklik = int.Parse(Console.ReadLine());
        Ucgen ucgen = new Ucgen(tabanUzunlugu,ucgenYukseklik);
        IslemSecenekleri(ucgen);
        break;
  }
}
catch (Exception e)
{
  Console.WriteLine(e.Message);
}

static void IslemSecenekleri(Sekil sekil)
{
   string className = sekil.GetType().Name;
   Console.WriteLine(className);
   Console.WriteLine("Yapmak istediginiz islemi seciniz.");
   Console.WriteLine("(1)Alan Hesapla");
   Console.WriteLine("(2)Cevre Hesapla");
   if(className == "Kare" || className == "Daire")
       Console.WriteLine("(3)Hacim Hesapla");
   int secim = int.Parse(Console.ReadLine());
   if(secim == 1)
   {
     double alan = 0;
     /*if(className == "Kare" || className == "Daire")
         alan = sekil.AlanHesapla();
     else //Ucgen ise
     {
       sekil = new Ucgen(tabanUzunlugu,yukseklik);
       alan = sekil.AlanHesapla();
     }*/
     alan = sekil.AlanHesapla();
     Console.WriteLine("Seklin alani: {0}",alan);
   }
   else if(secim == 2)
   {
      double cevre = 0;
      if(className == "Kare" || className == "Daire")
         cevre = sekil.CevreHesapla();
      else
      {
        cevre = UcgenCevresiHesapla();
      }
      Console.WriteLine("Seklin cevresi: {0}",cevre);
   }
   else //secim==3 => hacim hesaplama(kare ve daire icin)
   {
      double hacim = 0;
      hacim = sekil.HacimHesapla();
      Console.WriteLine("Seklin hacmi: {0}",hacim);
   }
}

static double UcgenCevresiHesapla()
{
   Console.Write("Ilk kenarin degerini giriniz: ");
   int kenar1 = int.Parse(Console.ReadLine());
   Console.Write("Ikinci kenarin degerini giriniz: ");
   int kenar2 = int.Parse(Console.ReadLine());
   Console.Write("Ucuncu kenarin degerini giriniz: ");
   int kenar3 = int.Parse(Console.ReadLine());
   Ucgen ucgen = new Ucgen(kenar1,kenar2,kenar3);
   return ucgen.CevreHesapla();  
}

abstract class Sekil
{
   public abstract double AlanHesapla();
   public abstract double CevreHesapla();
   public abstract double HacimHesapla(); 
}

class Kare : Sekil
{
    private int kenar;
    private int yukseklik; //hacim hesabi icin
    public Kare(int kenar)
    {
       this.kenar = kenar;
    }
    public int Yukseklik { get => yukseklik; 
    set{
        if(value>0)
           this.yukseklik=value;
        else
           this.yukseklik=1;
    }}

    public override double AlanHesapla() => this.kenar * this.kenar;
    public override double CevreHesapla() => this.kenar * 4;
    public override double HacimHesapla() => this.AlanHesapla() * this.Yukseklik;
}

class Daire : Sekil
{
    private int yaricap;
    private const double pi = Math.PI;
    public Daire(int yaricap)
    {
       this.yaricap = yaricap;
    }
    public override double AlanHesapla() => pi*(this.yaricap*this.yaricap);

    public override double CevreHesapla() => 2*pi*yaricap;

    public override double HacimHesapla() => 1.33 * pi * Math.Pow(yaricap,3); // 4/3 = 1.33 olarak alindi.
}

class Ucgen : Sekil
{
    private int tabanUzunlugu;
    private int yukseklik;
    private int kenar1, kenar2, kenar3;
    public Ucgen(int tabanUzunlugu, int yukseklik)
    {
      this.tabanUzunlugu = tabanUzunlugu;
      this.yukseklik = yukseklik;
    }
    public Ucgen(int kenar1,int kenar2,int kenar3)
    {
      this.kenar1 = kenar1;
      this.kenar2 = kenar2;
      this.kenar3 = kenar3;
    }
    public override double AlanHesapla() => (this.tabanUzunlugu * this.yukseklik)/2;

    public override double CevreHesapla() => kenar1+kenar2+kenar3;

    public override double HacimHesapla() => 1; //ucgen icin hacim hesabi yapilmiyor su anda
}