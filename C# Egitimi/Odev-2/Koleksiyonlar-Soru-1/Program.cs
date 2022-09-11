//Odev-2;
using System;
using System.Collections;
using System.Collections.Generic;

// Soru - 1: Klavyeden girilen 20 adet pozitif sayının asal ve asal olmayan olarak 2 ayrı listeye atın.
//(ArrayList sınıfını kullanarak yaziniz).
//Koleksiyonlar-Soru-1;
ArrayList lst1 = new ArrayList(); //asal
ArrayList lst2 = new ArrayList(); //asal olmayan
try
{
   for(int i=0;i<20;i++)
   {
     Console.Write("Sayi giriniz: ");
     int number = int.Parse(Console.ReadLine());
     if(number>0)
     {
       if(IsPrimeNumber(number)) //true
          lst1.Add(number);
       else
          lst2.Add(number);
     }     
   }
   Console.WriteLine("----Asal Sayilar---");
   //Elemanlari buyukten kucuge yazdirmak icin;
   lst1.Sort();
   lst1.Reverse();
   int sum=0;
   foreach(int item in lst1)
   {
     sum = sum+item;
     Console.WriteLine(item);
   }
   Console.WriteLine("Eleman sayisi: {0}",lst1.Count);
   Console.WriteLine("Degerlerin ortalamasi: {0}",((double)sum/(double)lst1.Count));
   sum=0;
      
   Console.WriteLine("----Asal Olmayan Sayilar---");
   //Elemanlari buyukten kucuge yazdirmak icin;
   lst2.Sort();
   lst2.Reverse();

   foreach(int item in lst2)
   {
      sum = sum+item;
      Console.WriteLine(item);  
   }

   Console.WriteLine("Eleman sayisi: {0}",lst2.Count);
   Console.WriteLine("Degerlerin ortalamasi: {0}",((double)sum/(double)lst2.Count));
   Console.WriteLine("-------"); 
}
catch (Exception e)
{
  Console.WriteLine(e.Message);
}
static bool IsPrimeNumber(int number)
{
   bool flag=true;
   for(int i = 2; i < number; i++)    
   {    
        if(number%i == 0)    
        {    
            flag=false;    
            break;    
        }    
   }    
   return flag;
}

