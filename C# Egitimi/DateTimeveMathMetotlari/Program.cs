//DateTime ve Math Kutuphanelerinin Metotlari;
Console.WriteLine(DateTime.Now); //guncel tarihi getirir
Console.WriteLine(DateTime.Now.Date); //guncel tarihin gun-ay-yil karsiligini getirir
Console.WriteLine(DateTime.Now.Day); //guncel tarihin gununu getirir
Console.WriteLine(DateTime.Now.Month);
Console.WriteLine(DateTime.Now.Year);
Console.WriteLine(DateTime.Now.Hour);
Console.WriteLine(DateTime.Now.Minute);
Console.WriteLine(DateTime.Now.Second);

Console.WriteLine(DateTime.Now.DayOfWeek); //haftanin gununu string halde getirir
Console.WriteLine(DateTime.Now.DayOfYear); //icinde bulununlan yilin kacinci gunundeysek onu int olarak doner.

Console.WriteLine(DateTime.Now.ToLongDateString());
Console.WriteLine(DateTime.Now.ToShortDateString());
Console.WriteLine(DateTime.Now.ToLongTimeString()); //saat:dakika:saniye
Console.WriteLine(DateTime.Now.ToShortTimeString()); //saat:dakika

Console.WriteLine(DateTime.Now.AddDays(2));
Console.WriteLine(DateTime.Now.AddHours(3)); 
Console.WriteLine(DateTime.Now.AddSeconds(30)); 
Console.WriteLine(DateTime.Now.AddMonths(5)); 
Console.WriteLine(DateTime.Now.AddYears(10)); 
Console.WriteLine(DateTime.Now.AddMilliseconds(50));

//DateTime Format;
Console.WriteLine(DateTime.Now.ToString("dd")); //04 (04.09.2022)
Console.WriteLine(DateTime.Now.ToString("ddd")); //Sun(bulunulan gunun string karsiligini getirir)
Console.WriteLine(DateTime.Now.ToString("dddd")); //Sunday

Console.WriteLine(DateTime.Now.ToString("MM")); //09
Console.WriteLine(DateTime.Now.ToString("MMM")); //Sep
Console.WriteLine(DateTime.Now.ToString("MMMM")); //September


Console.WriteLine(DateTime.Now.ToString("yy")); //22
Console.WriteLine(DateTime.Now.ToString("yyyy")); //2022

Console.WriteLine("----Math Kutuphanesi----");
//Math Kutuphanesi;
Console.WriteLine(Math.Abs(-25)); //mutlak deger alir ve 25 doner(poz.doner)
Console.WriteLine(Math.Sin(10)); //sinus hesabi yapar
Console.WriteLine(Math.Cos(10)); //cosinus hesabi yapar
Console.WriteLine(Math.Tan(10)); //tanjant hesabi yapar

Console.WriteLine(Math.Ceiling(22.3)); //verilen sayidan buyuk en kucuk tamsayiyi getirir(23)
Console.WriteLine(Math.Round(22.3)); //verilen sayi hangi tamsayiya daha yakinsa(burada 22) onu doner
Console.WriteLine(Math.Round(22.7)); //verilen sayi hangi tamsayiya daha yakinsa(burada 23) onu doner
Console.WriteLine(Math.Floor(22.7)); //22.7'den kucuk en buyuk tamsayiyi(int/22) getirir. Ceiling'in zitti gibi dusun yani.

Console.WriteLine(Math.Max(2,6)); 
Console.WriteLine(Math.Min(2,6)); 

Console.WriteLine(Math.Pow(3,4)); //3^4 = 81
Console.WriteLine(Math.Sqrt(9)); //karekok alir
Console.WriteLine(Math.Log(9)); //9'un e tabanindaki logaritmik karsiligi
Console.WriteLine(Math.Exp(3)); //e^3
Console.WriteLine(Math.Log10(10)); //10 sayisinin log10 tabanindaki karsiligi = 1




