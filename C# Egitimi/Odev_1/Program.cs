//Soru 1;
Console.Write("Kac adet sayi girmek istiyorsunuz?(pozitif sayi olarak belirtiniz): ");
try
{
    int sayi = int.Parse(Console.ReadLine());
    if(sayi >0)
    {
        Console.WriteLine();
        int deger = 0;
        for (int i=0; i<sayi; i++)
        {
        Console.Write("Sayi giriniz: ");
        deger = int.Parse(Console.ReadLine());
        if(deger%2==0)
            Console.WriteLine(deger);
        }
    }
    else
       Console.WriteLine("Pozitif bir sayi giriniz!");  
}
catch(System.Exception e)
{
  Console.WriteLine(e.Message);
}


//Soru 2;
try
{
    Console.Write("Pozitif 1.sayiyi giriniz: ");
    int n = int.Parse(Console.ReadLine());
    Console.WriteLine();
    Console.Write("Pozitif 2.sayiyi giriniz: ");
    int m = int.Parse(Console.ReadLine());
    if(n>0 && m>0)
    {
        Console.WriteLine();
        int deger = 0;
        for (int i=0; i<n; i++)
        {
        Console.Write("Sayi giriniz: ");
        deger = int.Parse(Console.ReadLine());
        if(deger == m || deger%m ==0)
            Console.WriteLine(deger);
        }
    }
    else
    Console.WriteLine("Pozitif bir sayi giriniz!");  
    }
catch(System.Exception e)
{
    Console.WriteLine(e.Message);
}


//Soru 3;
try
{
    Console.Write("Pozitif bir sayi giriniz:");
    int sayi = int.Parse(Console.ReadLine());
    if(sayi >0)
    {
        Console.WriteLine();
        string[] kelimeler = new string[sayi]; //dinamik boyut atamasi
        string kelime = "";
        for (int i=0; i<sayi; i++)
        {
           Console.Write("Kelime giriniz: ");
           kelime = Console.ReadLine(); 
           if(kelime != "")
              kelimeler[i] = kelime;
        }
        for(int i=kelimeler.Length-1; i>=0;i--)
        {
          Console.WriteLine(kelimeler[i]); 
        }
    }
    else
       Console.WriteLine("Pozitif bir sayi giriniz!");  
}
catch(System.Exception e)
{
  Console.WriteLine(e.Message);
}


//Soru 4;
try
{
    Console.Write("Bir cumle yaziniz: ");
    string cumle = Console.ReadLine();
    if(cumle != "")
    {
      string[] kelimeler = cumle.Split(" ");
      int kelimeSayisi = kelimeler.Length;
      int harfSayisi = 0;
      for (int i = 0; i<kelimeler.Length; i++)
      {
         harfSayisi += kelimeler[i].Length;
      }
      Console.WriteLine("Kelime sayisi:"+kelimeSayisi);
      Console.WriteLine("Harf sayisi:"+harfSayisi);
    }
    else
       Console.WriteLine("Pozitif bir sayi giriniz!");  
}
catch(System.Exception e)
{
      Console.WriteLine(e.Message);
}
