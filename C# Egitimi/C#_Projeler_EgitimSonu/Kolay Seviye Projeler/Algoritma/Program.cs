//C#-Algoritma;
using System;
try
{
   Console.Write("Icerisindeki metinsel ifadeleri ayirmak istediginiz cumleyi 'Algoritma,3 Algoritma,5 Algoritma,22 Algoritma,0' formatinda giriniz: ");
   string deger = Console.ReadLine();
   string[] splArray = deger.Split(" "); //[(Algoritma,3),(Algoritma,5)]
   List<string>kelimeler = new List<string>();
   for (int i = 0; i < splArray.Length; i++)
     kelimeler.Add(splArray[i].Split(",")[0]);
   kelimeler.ForEach(item => Console.Write(item+" "));
}
catch (Exception e)
{
  Console.WriteLine(e.Message);
}
