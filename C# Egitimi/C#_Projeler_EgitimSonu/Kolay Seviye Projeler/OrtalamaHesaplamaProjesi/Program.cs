//C#-Ortalama Hesaplama Projesi;
using System;
try
{
  Console.Write("Kac tane Fibonacci sayisinin ortalamasini almak istiyorsunuz(0'dan buyuk bir deger giriniz)? ");
  int deger = int.Parse(Console.ReadLine());
  FindTheFibonacciAverage(deger);
}
catch (Exception e)
{
   Console.WriteLine(e.Message);
}

static void FindTheFibonacciAverage(int derinlik)
{   
    double avg = 0;
    int fibValue=1;
    int[] degerler = new int[derinlik];
    if(derinlik>0)
    {
      for(int i=1; i<=derinlik;i++)
      {
         fibValue = FindFibonacciSum(i);
         degerler[i-1] = fibValue;
      }
      avg = FindTheAverage(degerler);
      Console.WriteLine("Fibonacci Degerlerinin Ortalamasi: {0}",avg);
    }
    else
    {
        Console.WriteLine("Girilen deger 0'dan buyuk olmalidir.");
        return;
    }
}

static int FindFibonacciSum(int deger)
{
   if(deger<=2) //ilk iki deger 1 1
     return 1;
   return FindFibonacciSum(deger-1) + FindFibonacciSum(deger-2);
}

static double FindTheAverage(int[] arr)
{
   int sum = 0;
   /*for(int i=0; i<arr.Length; i++)
      Console.WriteLine(arr[i]);*/
   for(int i=0; i<arr.Length; i++)
      sum += arr[i];
   return (double)sum/(double)arr.Length;
}