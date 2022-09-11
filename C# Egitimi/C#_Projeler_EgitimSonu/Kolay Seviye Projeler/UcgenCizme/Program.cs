//C#-Ucgen Cizdirme Projesi
using System;
try
{
   Console.Write("Ucgen cizdirmek icin 0'dan buyuk bir boyut giriniz: ");
   int boyut = int.Parse(Console.ReadLine());
   UcgenCiz(boyut);
}
catch (Exception e)
{
  Console.WriteLine(e.Message);
}

static void UcgenCiz(int boyut)
{
   if(boyut>0)
   {
    for(int i=1;i<=boyut;i++)
    {
        for(int j=0;j<i;j++)
            Console.Write("*");
        Console.WriteLine();
    }
   }
   else
   {
     Console.WriteLine("Girdiginiz boyut sifirdan kucuk olamaz!");
     return;
   }
}