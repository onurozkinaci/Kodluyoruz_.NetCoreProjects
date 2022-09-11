//Odev-2;
using System;
using System.Collections;
using System.Collections.Generic;

//Koleksiyonlar-Soru-3;
// Soru - 3: Klavyeden girilen cümle içerisindeki sesli harfleri bir dizi içerisinde saklayan 
//ve dizinin elemanlarını sıralayan programı yazınız.
try
{
    char[] sesliHarfler = {'a', 'e', 'ı', 'i', 'o', 'ö', 'u', 'ü'};
    List<char> harfListesi = new List<char>();
    Console.Write("Lutfen bir cumle giriniz: ");
    string cumle = Console.ReadLine();

    //Input'un tamsayi(int) degil, string veri tipinde oldugundan emin olmak icin;
    bool isNumber = int.TryParse(cumle, out int numericValue);
    if(isNumber) //true
       Console.WriteLine("Girdiginiz veri cumle olmalidir!");

    string[] kelimeler = cumle.Split(" ");
    for(int i=0; i<kelimeler.Length; i++)
    {
       char[] harfler = kelimeler[i].ToCharArray();
       for(int j=0; j<harfler.Length; j++)
       {
          if(sesliHarfler.Contains(harfler[j]))
            harfListesi.Add(harfler[j]);
       }   
    }
    //harfleri buyukten kucuge siralamak icin;
    harfListesi.Sort();
    harfListesi.Reverse();

    char[] sesliHarflerNew = harfListesi.ToArray();
    Console.WriteLine("-----Cumledeki Sesli Harfler----");
    for(int i=0; i<sesliHarflerNew.Length; i++)
       Console.WriteLine(sesliHarflerNew[i]);  
}
catch (Exception e)
{
   Console.WriteLine(e.Message);
}