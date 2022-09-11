//Ekrandan girilen sayiya kadar olan tek sayilari ekrana yazdir;
Console.Write("Lutfen bir sayi giriniz: ");
int sayac = int.Parse(Console.ReadLine());
for (int i = 0; i <= sayac; i++)
{
  //komutlar;
  if(i%2 ==1) //i%2 !=0
    Console.WriteLine(i);
}

//1 ve 1000 arasindaki tek ve cift sayilarin kendi iclerinde toplamlarini ekrana yazdir;
int tekToplam = 0, ciftToplam = 0;
for (int i = 1; i <= 1000; i++)
{
   if(i%2 ==1) //i%2 !=0 => tek sayi
     tekToplam += i; //tekToplam = tekToplam +i
   else //cift sayi
     ciftToplam +=i;
}
Console.WriteLine("Tek Sayilarin Toplami: " + tekToplam);
Console.WriteLine("Cift Sayilarin Toplami: " + ciftToplam);

//"break" ve "continue" keywordleri;
//break ile donguden cikilir, continue ile dongunun belirli bir kismina atlanir, mevcut cycle atlanir;
//**Not: İç içe döngüler kullanıldığında break ifadesi yalnızca içinde bulunduğu ilk döngüyü sonlandırır.
for (int i = 1; i < 10; i++)
{
   if(i==4) //i=4 olunca donguden cikar ve devam etmez(1,2,3 ekrana basilir ve donguden cikilir)
      break;
   Console.WriteLine(i);
}
Console.WriteLine("-------------------------");

for (int i = 1; i < 10; i++)
{
   if(i==4) //i=4 olunca mevcut cycle'i atlar ve diger cycle'dan devam eder, 4 haricindeki sayilari ekrana basar.
      continue;
   Console.WriteLine(i);
}

Console.WriteLine("-------------------------");
//=>While ve Foreach;
Console.WriteLine("--------------While ve Foreach-----------");
//While;
//1'den baslayarak consoledan girilen sayiya kadar(sayi dahil) ortalama hesaplayip console'a yazdiran program;
int a = 1; //sayac
Console.Write("Bir sayi giriniz: ");
int sayi = int.Parse(Console.ReadLine());
int toplam = 0;
// int adet = 0;
while (a<=sayi)
{
   toplam += a;
   Console.Write(a+"-");
   a++; //sayac
   // adet++;
}
Console.WriteLine();
// double ortalama = toplam/adet;
double ortalama = toplam/sayi;
Console.WriteLine("Ortalama: "+ortalama);

//a'dan z'ye kadar(z haric) tum harfleri konsola yazdir;
char character = 'a'; //baslangic degeri
while (character<'z')
{
   Console.Write(character);
   character++;
}

Console.WriteLine("-----Foreach-----");
//Foreach;
string[] arabalar = {"BMW","Ford","Toyota","Nissan"};
//'object' tipinden tureyen var veri tipi ile her tipten veri tutulabilir;
foreach (var araba in arabalar)
{
   Console.Write(araba +",");
}









