namespace Method_Overloading
{
  class  Program
  {
     static void Main(String[] args)
     {
        //Method Overloading ve 'Out' Parametresi;
        Console.WriteLine("---Method Overloading ve Out Parametresi---");
        //out parametreler;
        string sayi = "999";
        int outSayi;
        //TryParse ile verdigim degeri cevirebilirse(parse edebilirse) "out" ile cevrilen degeri bize donecek;
        bool sonuc = int.TryParse(sayi,out outSayi); //tanimlanmis bir degiskene(outSayi) atama yapmak yerine direkt metot icinde tanim yapmak da mumkun "out int outSayi" gibi.
        if(sonuc)
        {
          Console.WriteLine("Basarili");  
          Console.WriteLine(outSayi);  
        }
        else
           Console.WriteLine("Basarisiz"); 

        //out parametre ile metotta return kullanmadan(void metot) sonuc dondurup kullanmak;
        Metotlar instance = new Metotlar();
        instance.Topla(2,3,out int toplamSonuc);
        Console.WriteLine(toplamSonuc);

        //Method Overloading;
        int ifade = 999;
        instance.EkranaYazdir(Convert.ToString(ifade));
        instance.EkranaYazdir(ifade);
        instance.EkranaYazdir("Onur","Ozk");
     }
   }

   class Metotlar
   {
      public void Topla(int a, int b, out int toplam)
      {
        //return kullanmak yerine out ile gonderdigim ve out keyword'u ile parametre olarak tnaimladigim degiskene direkt atama yaptim 
        //ve donen deger aslinda onun degisen degeri olmus olacak direkt.
         toplam = a+b;
      }
      public void EkranaYazdir(string veri)
      {
        Console.WriteLine(veri);
      }

      //=>Method overloading, ayni isimdeki metot farkli parametre t ipi alacak sekilde ayni isimle tanimlanabilir.
      //Gonderilen parametre de 'Metot imzasina(metot adi+parametre sayisi+parametre tipi)'na gore gonderilir. Erisim belirtecei imzaya dahil olmadigindan
      //overloading icin public-private ayrimi yapip ayni isimde farkli metotlar kullanamazsin ornegin veya geri donus tipinin degisimi de bunu etkilemez ve hata alirsin.
      public void EkranaYazdir(int veri)
      {
        Console.WriteLine(veri);
      }
      public void EkranaYazdir(string veri1, string veri2)
      {
        Console.WriteLine(veri1+veri2);
      }

   }
}