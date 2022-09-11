//Hazir String Metotlari;
string degisken = "Dersimiz CSharp, Hosgeldiniz!";
string degisken2 = "Dersimiz CSharp";
//Length;
Console.WriteLine(degisken.Length); //string ifadenin karakter sayisini verir

//ToUpper, ToLower;
Console.WriteLine(degisken.ToUpper()); //string ifadenin tum karakterlerini buyutur
Console.WriteLine(degisken.ToLower()); //string ifadenin tum karakterlerini kucultur

//Concat => Verilen stringleri arrt arda baglar/birlestirir;
Console.WriteLine(String.Concat(degisken," Merhaba!")); //string ifadenin tum karakterlerini kucultur

//Compare,CompareTo;
Console.WriteLine(degisken.CompareTo(degisken2)); //Esitlerse 0, ilki daha buyukse 1, ilki/birinci degisken daha kucukse -1 doner(0,1,-1).
Console.WriteLine(String.Compare(degisken,degisken2,true));  //Compare() icin ignoreCase=true verince buyuk-kucuk harf duyarli olmadan karsilastirir.

//Contains;
Console.WriteLine(degisken.Contains(degisken2)); //true
Console.WriteLine(degisken.EndsWith("Hosgeldiniz!")); //true
Console.WriteLine(degisken.StartsWith("Merhaba!")); //false

//IndexOf;
Console.WriteLine(degisken.IndexOf("CS")); //ilk buldugu yerdeki C'nin(ilk harfin) index'ini doner, bulamazsa -1 doner
Console.WriteLine(degisken.IndexOf("CA")); //-1 doner
//LastIndexOf;
Console.WriteLine(degisken.LastIndexOf("i")); //birden cok 'i' bulursa da son buldugunu doner.

//Insert => String'e belirtilen index'e gore ekleme yapar;
Console.WriteLine(degisken.Insert(0,"Merhaba ")); //0.index'e Merhaba'yi ekler.

//PadLeft,PadRight;
Console.WriteLine(degisken + degisken2.PadLeft(30)); //degisken2'nin soluna 30 karaktere tamamlayacak kadar bosluk ekler, karakter sayisi 30'dan kucuk ise.
Console.WriteLine(degisken + degisken2.PadLeft(30,'*')); //Belirli bir karakter eklemek istersem o bosluk yerine.
Console.WriteLine(degisken.PadRight(50) + degisken2); // "degisken" in sagina bosluk ekler(50 karaktere tamamlayacak sekilde).
Console.WriteLine(degisken.PadRight(50,'-') + degisken2); 

//Remove;
Console.WriteLine(degisken.Remove(10)); //10.indexten baslayarak sona kadar siler.
Console.WriteLine(degisken.Remove(5,3)); //Aradan siler, 5.indexten baslayarak 3 tane karakter siler.
Console.WriteLine(degisken.Remove(0,1)); //En bastakini siler.

//Replace;
Console.WriteLine(degisken.Replace("CSharp","C#")); 
Console.WriteLine(degisken.Replace(" ","*")); 

//Split;
Console.WriteLine(degisken.Split(' ')[1]); //verilen string'i bosluklara gore parcala ve diziye ata, 1.indexi getir demis oluyoruz. 

//Substring;
Console.WriteLine(degisken.Substring(4)); //verilen string'in 4.indexinden sonuna kadar olan karakterleri getirir.
Console.WriteLine(degisken.Substring(4,6)); //verilen string'in 4.indexinden baslayarak 6 tane karakteri getirir.









