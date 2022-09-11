// See https://aka.ms/new-console-template for more information
/*int a,b;
a = 5;
b = 6;
Console.WriteLine(a+b);
*/

//Atama ve Islemli Atama;
Console.WriteLine("---Atama ve Islemli Atama---");
int x = 3;
int y = 3;
y = y+2;
y += 2; //ustteki ifadenin aynisi-islemli atama
//Ornek: y=y+1, y +=1 ve y++ da birbiri yerine kullanilabilen ifadelerdir.
Console.WriteLine(y);
y/=1;
Console.WriteLine(y);
x *= 2; // x = x*2
Console.WriteLine(x);

//Mantiksal Operatorler (||, &&, !);
Console.WriteLine("---Mantiksal Operatorler---");
bool isSuccess = true;
bool isCompleted = false;
if(isSuccess && isCompleted)
   Console.WriteLine("Perfect!");
if(isSuccess || isCompleted) //calisir, birisi true
   Console.WriteLine("Great!");
if(isSuccess && !isCompleted) //calisir, ilki true, ikincisi false
   Console.WriteLine("Fine!");

//Iliskisel Operatorler(< ,> ,<=, >=, ==, !=);
Console.WriteLine("---Iliskisel Operatorler---");
int a = 3;
int b = 4;
bool sonuc = a<b; //true
Console.WriteLine(sonuc);
sonuc = a>b; //false
Console.WriteLine(sonuc);
sonuc = a>=b; //false
Console.WriteLine(sonuc);
sonuc = a<=b; //true
Console.WriteLine(sonuc);
sonuc = a==b; //false
Console.WriteLine(sonuc);
sonuc = a!=b; //true
Console.WriteLine(sonuc);

//Artimetik Operatorler(/, *, +, -);
Console.WriteLine("---Aritmetik Operatorler---");
int sayi1 = 10;
int sayi2 = 5;
int sonuc1 = sayi1 / sayi2;
Console.WriteLine(sonuc1);
sonuc1 = sayi1 * sayi2;
Console.WriteLine(sonuc1);
sonuc1 = sayi1 + sayi2;
Console.WriteLine(sonuc1);
sonuc1 = sayi1 - sayi2;
Console.WriteLine(sonuc1);
sonuc1 = ++sayi1; //sayi1++ verirsen sonradan artirir(post increment).
Console.WriteLine(sonuc1);

//%:Mod almak icin => bolmeden kalani verir;
int sonuc2 = 20%3;
Console.WriteLine(sonuc2);




   
