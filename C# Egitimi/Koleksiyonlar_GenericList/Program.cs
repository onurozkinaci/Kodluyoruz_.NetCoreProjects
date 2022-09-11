//Koleksiyonlar-Generic List;
using System.Collections.Generic;
// List<T>class;
// T -> (generic)object turundedir, liste icerisindeki nesnelerin tipini ifade eder.
/*
->Generic list System.Colections.Generic isim uzayı altında bulunan bit list sınıfı koleksiyonudur. 
->Generic List bir list sınıfı tanımlarken T olarak tip değişkenini alır. Generic olmasını sağlayan da burdaki T veri tipidir. T listenin hangi türden veri tutacağını belirler. 
->Bu tanımlama sonunda farklı türden bir veri tipini generic list ile saklayamazsınız.
*/

List<int>sayiListesi = new List<int>();
sayiListesi.Add(23);
sayiListesi.Add(10);
sayiListesi.Add(4);
sayiListesi.Add(5);
sayiListesi.Add(92);
sayiListesi.Add(34);


List<string>renkListesi = new List<string>();
renkListesi.Add("Kirmizi");
renkListesi.Add("Mavi");
renkListesi.Add("Turuncu");
renkListesi.Add("Sari");
renkListesi.Add("Yesil");

//Count;
Console.WriteLine(renkListesi.Count);
Console.WriteLine(sayiListesi.Count);

foreach (var sayi in sayiListesi)
    Console.WriteLine(sayi);
foreach (var renk in renkListesi)
    Console.WriteLine(renk);

sayiListesi.ForEach(sayi => Console.WriteLine(sayi));
renkListesi.ForEach(renk => Console.WriteLine(renk));
Console.WriteLine("------------------");

//Listeden eleman cikarma(2 farkli metot ile);
//Elemana gore silmek icin;
sayiListesi.Remove(4);
renkListesi.Remove("Yesil");
sayiListesi.ForEach(sayi => Console.WriteLine(sayi));
renkListesi.ForEach(renk => Console.WriteLine(renk));
Console.WriteLine("------------------");

//Index'e gore silmek icin
sayiListesi.RemoveAt(0);
renkListesi.RemoveAt(1);
Console.WriteLine("------------------");
sayiListesi.ForEach(sayi => Console.WriteLine(sayi));
renkListesi.ForEach(renk => Console.WriteLine(renk));

//Liste icerisinde arama;
if(sayiListesi.Contains(10))
   Console.WriteLine("Liste icerisinde bulundu!");

//Eleman ile index'e erisme => BinarySearch'u kullanarak;
Console.WriteLine(renkListesi.BinarySearch("Kirmizi")); //verilen elemanin index'ini getirir.

//Diziyi List'e cevirme;
string[] hayvanlar = {"Kedi", "Kopek", "Kus"};
List<string>hayvanListesi = new List<string>(hayvanlar);

//Tum Listeyi(List) temizleme;
hayvanListesi.Clear();

//List icerisinde nesne(bu ornek icin classtan turetilen objeler) tutmak;
List<Kullanicilar>kullaniciListesi = new List<Kullanicilar>();
Kullanicilar k1 = new Kullanicilar();
k1.Isim = "Onur";
k1.SoyIsim = "Ozk";
k1.Yas = 22;

Kullanicilar k2 = new Kullanicilar();
k2.Isim = "Ali";
k2.SoyIsim = "Demir";
k2.Yas = 20;

kullaniciListesi.Add(k1);
kullaniciListesi.Add(k2);

//Ekleme yapmanin bir baska yolu, objeyi ayri tanimlamadan direkt acilan Add({}) icerisinde eklemektir;
List<Kullanicilar> yeniListe = new List<Kullanicilar>();
yeniListe.Add(new Kullanicilar()
{
   Isim = "Deniz",
   SoyIsim = "Arda",
   Yas = 24
}
);
//yeniListe.ForEach(item => Console.WriteLine(item.Isim));

Console.WriteLine("---------");
foreach (var kullanici in kullaniciListesi) //var yerine Kullanicilar da yazabilirsin direkt
{
  Console.WriteLine("Kullanici Adi: " + kullanici.Isim);  
  Console.WriteLine("Kullanici Soyadi: " + kullanici.SoyIsim);  
  Console.WriteLine("Kullanici Yasi: " + kullanici.Yas);  
  Console.WriteLine("---------");
}
yeniListe.Clear(); //isim bittiginde listenin icerisini temizleyebilirim.
//Console.WriteLine(yeniListe);

public class Kullanicilar 
{
   private string isim;
   private string soyIsim;
   private int yas;

    public string Isim { get => isim; set => isim = value; }
    public string SoyIsim { get => soyIsim; set => soyIsim = value; }
    public int Yas { get => yas; set => yas = value; }
}

