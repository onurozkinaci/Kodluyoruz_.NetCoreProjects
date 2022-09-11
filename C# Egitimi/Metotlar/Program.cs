//Metotlar;
//Programlari parcalamak amaciyla kullanilir ve OOP ile birlikte fonksiyonlar aslinda metot adini almistir denebilir;
//Metotlar classlar icerisinde yazilmalidir ve baska class'tan erisilen metota instance uzerinden erisilir;

using System;
namespace Metotlar
{
  class Program
  {
    static void Main(String [] args)
    {
        // //erisim belirteci geri_donustipi metot_adi(parametreListesi/arguman)
        // {
        //     //komutlar;
            //return;
        // }

        int a = 2;
        int b =3;
        //Console.WriteLine(a+b);
        int sonuc = Topla(a,b); //Ayni class icerisinde olusturulan metoda direkt ismi uzerinden ulasilabilir.
        //Console.WriteLine(sonuc);

        //Bulunulan degil baska class'a ait bir metoda erismek icin class'in instance'ini almak gerekir;
        Metotlar ornek = new Metotlar();
        ornek.EkranaYazdir(sonuc.ToString());
        
        int sonuc2 = ornek.ArtirVeTopla(ref a, ref b);
        ornek.EkranaYazdir(sonuc2.ToString());
        ornek.EkranaYazdir((a+b).ToString());
    }  

    //'static' metodun(main) icerisinde cagrilan metodun da static olmasi gerekir;
    static int Topla(int num1, int num2)
    {
      return num1+num2;
    }
  } 

  class Metotlar
  {
     public void EkranaYazdir(string veri)
     {
        Console.WriteLine(veri);
     }
     public int ArtirVeTopla(ref int deger1, ref int deger2)
     {
        deger1 +=1;
        deger2 +=1;
        return deger1+deger2;
     }
  }
}

/*
//*** =>Not;
//Metotlarda genelde 'call by value' mantigi vardir ve metoda gonderilen argumentlarin degerleri onlari metotta karsilayan 
// parametreler ile tutularak bu parametreler de fonksiyonun yasam suresi kadar islem saglayacak sekilde(fonksiyon disindan ulasilamaz)
// bu degerler uzerinden islem yapabilir ve bu islemlerden disarida metota degeri gonderen degiskenler etkilenmez ve bu duruma 'call by value'
// adi verilir. 'call by reference' ise, metottaki parametrelerin basina 'ref' verilirse yapilan islemlerin argumentlarin referans yani memoryde tuttuklari
//yeri de etkileyecek sekilde atanmasina neden olur.
//'ref' keyword'u ile birlikte, fonksiyona argumentlarin degerini degil de bellekteki karsiliklari/adresleri verilmis olur ve orijinal degiskenler uzerinde 
//degisiklik yapilmis olur. 'call by value' ornegi icin yukarida ekranaYazdir() verildi ve 'call by reference' icin de ArtirVeTopla() metodu ornek olarak verildi.
//Ayni zamanda 'call by reference' a gonderilen argumentlarin basinda da 'ref' keyword'u kullanilmalidir!
*/