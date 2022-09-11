//C#-Mutlak Kare Alma;
try
{
   Console.WriteLine("'56 45 68 77' formatinda ikili halde sayilarin toplamlarini almak icin degerleri giriniz.");
   string degerler = Console.ReadLine();
   string[] sptDegerler = degerler.Split(" ");
   int sonuc = 0, toplamKucuk = 0, toplamBuyuk=0, deger1 = 0;
   for(int i=0; i<sptDegerler.Length; i++)
   {
      int.TryParse(sptDegerler[i],out deger1);
      if(deger1<67)
      {
        sonuc = 67 - deger1;
        toplamKucuk += sonuc;
      }
      else
      {
        sonuc = Convert.ToInt32(Math.Pow(Math.Abs(67-deger1),2));
        toplamBuyuk += sonuc;
      }
   }
   Console.WriteLine(toplamKucuk +" "+toplamBuyuk);
}
catch (System.Exception e)
{
  Console.WriteLine(e.Message);
}


