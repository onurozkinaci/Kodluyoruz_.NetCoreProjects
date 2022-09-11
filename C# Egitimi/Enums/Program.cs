//Enums-Enumeration-Siralama;
Console.WriteLine(Gunler.Pazar);
Console.WriteLine((int)Gunler.Cumartesi); //int degerini ekrana basmak icin integer'a cast etmek gerekir.
Console.WriteLine("----------------"); //int degerini ekrana basmak icin

int sicaklik = 32;
if(sicaklik <= (int)HavaDurumu.Normal)
   Console.WriteLine("Disariya cikmak icin havanin biraz daha isinmasini bekleyiniz.");
else if(sicaklik >= (int) HavaDurumu.Sicak)
   Console.WriteLine("Disariya cikmak icin cok sicak bir gun.");
else if(sicaklik >= (int)HavaDurumu.Normal && sicaklik < (int) HavaDurumu.Cok_Sicak)
   Console.WriteLine("Hadi disariya cikalim!");


//Birden fazla sabite(degeri belirli veri) ihtiyac olan durumlarda 
//okunurlugu(metotlardaki mantikla direkt isimlendirmeden ne yapacaginin anlasilmasi gibi) artirmak icin enumlar kullanilabilir;
enum Gunler
{
  Pazartesi = 1, //indexi otomatik 0 olarak atanir ilk elemanin ve sonrakiler de sirasiyla atanir otomatik olarak,manuel bu degerleri 
  //degismek icin ornegin baslangic degerini 1 verip diger degerlerin de sirasini degisirsin aslinda (0-1-2 yerin 1-2-3 olarak ilerler artik).
  Sali,
  Carsamba,
  Persembe,
  Cuma = 23,
  Cumartesi, //24 olacak, her veri bir oncekine bakarak ardisik devam eder.
  Pazar
}

//Sabit degiskenleri tutmak icin de kullanilabilir;
enum HavaDurumu
{
  Soguk = 5,
  Normal = 20,
  Sicak = 25,
  Cok_Sicak = 30
}


