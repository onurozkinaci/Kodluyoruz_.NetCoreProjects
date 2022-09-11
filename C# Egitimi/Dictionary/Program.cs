//Collections-Dictionary Kullanimi;
/*Dictionary: "key-value" pairlari halinde deger tutarlar. Index yerini key alir da denebilir.
//Her key unique(essiz)olmalidir.
//Dictionaryler Generic Listler gibi System.Collections.Generic altinda bulunur.
*/
using System.Collections.Generic;

Dictionary<int,string> kullanicilar = new Dictionary<int, string>();//<keys' data type,values' data type>
kullanicilar.Add(10,"Ayse Yilmaz");
kullanicilar.Add(12,"Ahmet Yilmaz");
//kullanicilar.Add(12,"Ahmet Yilmaz"); //=>Keylerin unique olmasi gerektiginden, bunu eklemeye calistiginda runtime error alirsin!
kullanicilar.Add(18,"Deniz Arda");
kullanicilar.Add(20,"Ozcan Cosar");

//Dizinin elemanlarina erisim;
Console.WriteLine("---Dictionary Elemanlarina Erisim-----");
Console.WriteLine(kullanicilar[12]); //12 key'ine sahip elemani getirir.
foreach (var item in kullanicilar)
    Console.WriteLine(item);

//Count;
Console.WriteLine("---Count----");
Console.WriteLine(kullanicilar.Count);

//Contains;
Console.WriteLine("---Contains----");
Console.WriteLine(kullanicilar.ContainsKey(12)); //true
Console.WriteLine(kullanicilar.ContainsValue("Onur Ozk")); //false

//Remove => Dictionary'den eleman cikarma;
Console.WriteLine("---Remove----");
kullanicilar.Remove(12); //verilen key uzerinden o elemani Dictionary'den siler.
foreach (var item in kullanicilar)
    Console.WriteLine(item.Value); //item."Value" ile sadece degerleri yazdirabilirsin.

//Keys;
Console.WriteLine("---Keys----");
//Sadece dictionary'nin keyleri uzerinde islem yapmak icin("Keys");
foreach (var item in kullanicilar.Keys)
   Console.WriteLine(item);

//Values;
Console.WriteLine("---Values----");
//Sadece dictionary'nin valuelari uzerinde islem yapmak icin("Values");
foreach (var item in kullanicilar.Values)
   Console.WriteLine(item);