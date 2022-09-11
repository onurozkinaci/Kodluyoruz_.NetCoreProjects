//instance aldik(nesne olusturma);
Ogrenci ogrenci = new Ogrenci();
ogrenci.Isim = "Ayse";
ogrenci.Soyisim = "Yilmaz";
ogrenci.OgrenciNo = 293;
ogrenci.Sinif = 3;
ogrenci.OgrenciBilgileriniGetir();
ogrenci.SinifAtlat();
ogrenci.OgrenciBilgileriniGetir();

Ogrenci ogrenci2 = new Ogrenci("Deniz","Arda",256,1);
ogrenci2.SinifDusur();
ogrenci2.SinifDusur();
ogrenci2.OgrenciBilgileriniGetir();


//=>Encapsulation ve Property/Ozellik Kavramlari;
/*=>Encapsulation, bir nesnenin bazi ozelliklerini,islevlerini,metotlarini diger classlardan
veya metotlardan erisim belirtecleri (access modifier) ile korumaktir denebilir.
-Ornegin private bir field'nin erisilebilirligini ve kontrollerini belirledigimiz get ve set yardimiyla
kolayca saglayabiliriz. Encapsulation dedigimiz kisim da private field'in adina benzer bir adda acilmis olan public
property icerisinde verilen get ve set kontrolleri ile bu ozelligin erisilebilirligini kontrol etmeye verilen isimdir denebilir.
-Setter vermezsen deger atayamazsin ve sadece getter olunca da readonly bir encapsulation alanina atama yapilamaz seklinde hata verir.
-Getter ve setter ile private kullanilan bir field'i encapsulation mantigi ile kapsullemenin sagladigi en temel fayda, disaridan ozellige
bir deger atanmak istediginde bunun kontrol edilmesini saglamaktir. Ornegin yas ozelligini(field) private tanimlayip daha sonra public olarak
tanimlanan Yas property'si icerisindeki get; ve set; metotlari ile bunu kontrol ederek, set icerisinde yas 0'dan buyukse atamaya izin vermesi gibi kontroller
saglanabilir.
*=> "enum" anahtar kelimesi enumeration yani numaralandırma kelimesinden gelir. Sayısal verilerı string ifadelerle saklamanızı sağlar. 
Okunabilirliğe katkısı da tam olarak burdan gelir diyebiliriz.
*/
class Ogrenci
{
    private string isim; //field
    private string soyisim;
    private int ogrenciNo;
    private int sinif;

    public string Isim //property
    {   get => isim; 
        //get{return isim}
        set => isim = value; 
        //set{isim=value}
    }
    public string Soyisim { get => soyisim; set => soyisim = value; }
    public int OgrenciNo { get => ogrenciNo; set => ogrenciNo = value; }
    public int Sinif 
    { get => sinif; 
      set 
      {
        //Sinifin en az 1 olmasi gerektigi icin disaridan atanan degerin kontrolu icin;
        if(value<1)
        {
          Console.WriteLine("Sinif en az 1 olabilir!");
          sinif = 1;  
        }
        else
           sinif = value;  
      }  
    }

    //Constructor => default one;
    public Ogrenci(string isim, string soyisim, int ogrencino, int sinif)
    {
        Isim = isim; //public degere atayarak set etmis oluyoruz private isim property'si icin
        Soyisim = soyisim;
        OgrenciNo = ogrencino;
        Sinif = sinif;
    }

    //Overloading the constructor;
    public Ogrenci(){}

    public void OgrenciBilgileriniGetir()
    {
       Console.WriteLine("---------------Ogrenci Bilgileri-----------------");
       Console.WriteLine("Ogrenci Adi: {0}", this.Isim);
       Console.WriteLine("Ogrenci Soyadi: {0}", this.Soyisim);
       Console.WriteLine("Ogrenci No: {0}", this.OgrenciNo);
       Console.WriteLine("Ogrenci Sinifi: {0}", this.Sinif);  
    }
    public void SinifAtlat()
    {
      this.Sinif = this.Sinif+1;
    }
    public void SinifDusur()
    {
      this.Sinif = this.Sinif-1;
    }

}

