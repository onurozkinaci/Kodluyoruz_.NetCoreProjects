/*
//Diziler;
//Ayni tipteki degiskenleri bellekte arka arkaya saklamak icin kullanilabilir.
//Eleman tipleri dizi icin ayni olmalidir, string[] bir dizinin elemanlari yalnizca string olabilir gibi.

//Dizi Tanimlama;
string[] renkler = new string[5];//dizi elemanlari belirli degil ise,sonradan eklenecekse
string[] hayvanlar = {"Kedi","Kopek","Kus","Maymun"}; //dizi elemanlari belirli ise

int[] dizi;
dizi = new int[5];

//Dizilere deger atama ve erisim;
renkler[0] = "Mavi"; //deger atama
//Console.WriteLine(hayvanlar[0]);//dizi elemanina erisim
dizi[3] = 10;
Console.WriteLine(hayvanlar[1]);
Console.WriteLine(dizi[3]);
Console.WriteLine(renkler[0]);
Console.WriteLine("---------------------------------");

//Dongulerle dizi kullanimi;
//Klavyeden girilen n tane sayinin ortalamasini alan program;
Console.Write("Lutfen dizinin eleman sayisini giriniz:");
int diziUzunlugu = int.Parse(Console.ReadLine());
//Dinamik bir sekilde konsoldan kullanicinin girdigi uzunluk degeri ile array uzunlugu atanir;
int[] sayiDizisi = new int[diziUzunlugu];
for (int i = 0; i < diziUzunlugu; i++)
{
   Console.Write("Lutfen {0}. sayiyiyi giriniz: ",i+1); 
   sayiDizisi[i] = int.Parse(Console.ReadLine());
}

int toplam=0;
foreach (var sayi in sayiDizisi)
    toplam += sayi;

Console.WriteLine("Dizinin ortalamasi: " + toplam/sayiDizisi.Length); //toplam/diziUzunlugu;
Console.WriteLine("-----------------------------------------------------------");
*/

//Array Sinifi Metotlari;
Console.WriteLine("---------Array Sinifi Metotlari-----------------");
//Sort-Siralama;
int[] sayiDizisiNew = {23,12,4,86,72,3,11,17};
Console.WriteLine("--Sirasiz Dizi--");
foreach (var sayi in sayiDizisiNew)
{
   Console.Write(sayi+","); 
}
Console.WriteLine("------------");

Console.WriteLine("--Sirali Dizi--");
Array.Sort(sayiDizisiNew);
foreach (var sayi in sayiDizisiNew)
{
   Console.Write(sayi+","); 
}
Console.WriteLine("------------");

//Clear - Verilen indexten baslayip verilen eleman sayisi kadar dizide sifirlama islemi yapar;
Console.WriteLine("--Array.Clear()--");
Array.Clear(sayiDizisiNew,2,2); //2.indexten baslayarak 2 tane elemani temizle demis oluyoruz.
//2. ve 3.indexteki sayilar 0 olarak degistirilir.
foreach (var sayi in sayiDizisiNew)
{
   Console.WriteLine(sayi); 
}

//Reverse -> Tersine cevirme islemi;
Console.WriteLine("--Array.Reverse()--");
Array.Reverse(sayiDizisiNew);
foreach (var sayi in sayiDizisiNew)
{
   Console.WriteLine(sayi); 
}

//IndexOf -> Verilen dizide verilen eleman mevcut ise o elemanin index'ini doner;
Console.WriteLine("--Array.IndexOf()--");
Console.WriteLine(Array.IndexOf(sayiDizisiNew,23)); 

//Resize -> Yeniden boyutlandirma yapar;
Console.WriteLine("--Array.Resize()--");
Array.Resize<int>(ref sayiDizisiNew,9); //mevcut dizinin boyutunu/eleman sayisini 9 yapar. 'int' dizimizin tipine karsilik gelir.
//Fazla olan degerler yerine de o andaki array tipine gore(burada int old. icin 0 atamasi yapar) deger atamasi yapar.
sayiDizisiNew[8] = 99;
foreach (var sayi in sayiDizisiNew)
{
   Console.WriteLine(sayi); 
}