//C Ile Karakterleri Tersten Yazdirma;
using System;
try
{
   Console.Write("Bir cumle giriniz: ");
   string cumle = Console.ReadLine();
   string[] kelimeler = cumle.Split(" ");
   for(int i=0; i<kelimeler.Length; i++)
   {
     //Console.WriteLine(kelimeler[i]);
     char[] harfler = kelimeler[i].ToCharArray();
     for(int j=0; j<harfler.Length;j++)
     {
        char temp = harfler[j];
        if(j+1 != harfler.Length)
        {
          harfler[j] = harfler[j+1];
          harfler[j+1] = temp;
        }
        //Console.WriteLine(harfler[j]);
     }
     kelimeler[i] = new string(harfler); //ilgili kelime degismis hali ile guncellenir.  
   }
   Console.WriteLine(string.Join(" ",kelimeler));
}
catch (Exception e)
{
  Console.WriteLine(e.Message);
}