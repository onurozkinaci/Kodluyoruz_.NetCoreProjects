//Odev-2;
//Koleksiyonlar-Soru-2;
// Soru - 2: Klavyeden girilen 20 adet sayının en büyük 3 tanesi ve en küçük 3 tanesi bulan, 
//her iki grubun kendi içerisinde ortalamalarını alan ve bu ortalamaları ve ortalama toplamlarını 
//console'a yazdıran programı yazınız. (Array sınıfını kullanarak yazınız.)
try
{
   int[] allNumbers = new int[20];
   int maxSum=0 ,minSum=0;
   for(int i=0;i<20;i++)
   {
     Console.Write("Sayi giriniz: ");
     int number = int.Parse(Console.ReadLine());
     allNumbers[i] = number;
   }

   //arrayi buyukten kucuge siralamak icin;
   Array.Sort(allNumbers);
   Array.Reverse(allNumbers);

   int length = allNumbers.Length;
   for(int i=0;i<allNumbers.Length;i++)
   {
      if(i==0 || i==1 || i==2)
        maxSum += allNumbers[i];
      if(i==length-1 || i==length-2 || i==length-3)
        minSum += allNumbers[i];
   }
   Console.WriteLine("Max sayilarin ortalamasi: {0}",((double)maxSum/3.0));
   Console.WriteLine("Min sayilarin ortalamasi: {0}",((double)minSum/3.0));
   Console.WriteLine("Ortalamalarin toplami: {0}",((double)maxSum/3.0+(double)minSum/3.0));
}
catch (Exception e)
{
  Console.WriteLine(e.Message);
}

