//Collections-ArrayList;
//Bir koleksyion tipi oldugundan Generic List'ten farkli olarak
//farkli veri tiplerini tek bir koleksiyon icerisinde barindirabilir!
//own=> Generic List'i dinamik arrayler gibi de dusunebilirsin.
using System.Collections;

ArrayList list = new ArrayList();
/*list.Add("Onur");
list.Add(2);
list.Add(true);
list.Add('A');
*/

//Icerisindeki verilere erisim;
//Console.WriteLine(list[1]);
Console.WriteLine("----------------");
foreach(var item in list)
   Console.WriteLine(item);
Console.WriteLine("----------------"); 

//*AddRange => Birden cok elemani toplu halde ekleme;
//string[] renkler = {"kirmizi","sari","yesil"};
List<int>sayilar = new List<int>(){1,8,3,7,9,92,5};
//list.AddRange(renkler);
list.AddRange(sayilar);
foreach(var item in list)
   Console.WriteLine(item);
Console.WriteLine("----------------"); 

//Sort;
list.Sort(); //arraydeki elemanlari compare edemediginden hata verir cunku farkli veri tipleri bulunuyor ArrayList'te.
//Karsilastirma yapilarak siralanabilmeleri icin Arraylist elemanlarinin ayni veri tipine sahip olmasi gerekiyor.
//Sorts in ascending order. Generic Listler icin de Sort() gecerlidir. Asagidaki ornek gibi;
/*
List<int>deneme = new List<int>{4,2,3,4};
deneme.Sort();
deneme.ForEach(item => Console.WriteLine(item));
*/
foreach(var item in list)
   Console.WriteLine(item);
Console.WriteLine("----------------"); 

//Binary Search => Kullanmak icin oncelikle icerisinde aramas yapilacakk List(generic list) veya Arraylist gibi yapilarin
//siralanmasi ve sonrasinda BinarySearch'e basvurulmasi gerekmektedir;
Console.WriteLine(list.BinarySearch(9));
Console.WriteLine("---------------");

//Reverse => Sort ile kucukten buyuge siralama sonrasinda Reverse() kullanarak listeyi buyukten kucuge de siralayabilirsin;
list.Reverse();
foreach (var item in list)
    Console.WriteLine(item);
Console.WriteLine("---------------");

//Clear => Liste elemanlarini temizler;
list.Clear();
foreach (var item in list)
    Console.WriteLine(item);
Console.WriteLine("---------------");