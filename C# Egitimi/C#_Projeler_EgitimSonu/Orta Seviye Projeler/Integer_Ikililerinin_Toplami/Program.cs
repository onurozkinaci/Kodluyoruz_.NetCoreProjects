//C#-Integer Ikililerinin Toplami;
try
{
   Console.WriteLine("'2 3 1 5 2 5 3 3' formatinda ikili halde sayilarin toplamlarini almak icin degerleri giriniz.");
   string degerler = Console.ReadLine();
   string[] sptDegerler = degerler.Split(" ");
   int toplam = 0, deger1=0, deger2=0;
   for(int i=0; i<sptDegerler.Length; i++)
   {
      if(i+1 != sptDegerler.Length)
      {
        int.TryParse(sptDegerler[i],out deger1);
        int.TryParse(sptDegerler[i+1],out deger2);
        if(sptDegerler[i] == sptDegerler[i+1])
            toplam = Convert.ToInt32(Math.Pow((deger1 + deger2),2));
        else
            toplam = deger1 + deger2;
        Console.Write(toplam + " ");
        ++i; //ikili olarak toplama bakildiktan sonra bir sonraki degere gecmek icin
      }
   }
}
catch (System.Exception e)
{
  Console.WriteLine(e.Message);
}

