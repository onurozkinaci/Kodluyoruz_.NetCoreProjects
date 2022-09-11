// See https://aka.ms/new-console-template for more information

// DateTime dt1 = DateTime.Now;
// Console.WriteLine("Current date is: " + dt1);

byte b = 5; //1 byte
sbyte c = 5; //1 byte

short s = 5; //2 byte
ushort us = 5; //2 byte

Int16 i16 = 2; //2 byte
int i =2; //4 byte
Int32 i32 = 2; //4 byte
Int64 i64 = 2; //8 byte
uint ui = 2; //4 byte => 'unsigned' int, - deger kabul etmemektedir.
long l = 4; //8 byte =>int'e gore daha buyuk degerler tutulmasi halinde kullanilabilir.

//Reel Sayilar;
float f = 5; //4 byte
double d = 5; //8 byte
decimal de = 5; //16 byte

char ch = '2'; //2 byte
string str = "Onur"; //sinirsiz

bool b1 = true;
bool b2 = false;

DateTime dt = DateTime.Now;
Console.WriteLine(dt);

//Tum degerler object veri tipinden turediginden, object ile tanimlanmalari da mumkundur;
object o1 = "x";
object o2 = "y";
object o3 = 4;
object o4 = 4.3;
object o5 = DateTime.Now;

//String ifadeler;
string str1 = string.Empty; //"" veya null da kullanilabilir
str1 = "Onur Ozk";
string ad = "Onur";
string soyad = "Ozk";
string tamIsim = ad + " " + soyad;
Console.WriteLine(tamIsim);

//integer tanimkama sekilleri;
int integer1 = 5;
int integer2 = 3;
int integer3 = integer1 + integer2;

//boolean;
bool bool1 = 10>2; //true
Console.WriteLine(bool1);

//*Degisken Donusumleri;
string str20 = "20";
int int20 = 20;
string yeniDeger = str20+ int20.ToString(); //2020
Console.WriteLine(yeniDeger);

int int21 = int20 + Convert.ToInt32(str20);
Console.WriteLine(int21); //output => 40

int int22 = int20 + int.Parse(str20); //output => 40
Console.WriteLine(int22);

//DateTime;
string dateTime = DateTime.Now.ToString("dd.MM.yyyy"); //GUncel/anlik tarih, 'gun.ay.yil' olarak formatlanir ve string'e cevrilir.
Console.WriteLine(dateTime); //output => 01.09.2022

string dateTime2 = DateTime.Now.ToString("dd-MM-yyyy"); //GUncel/anlik tarih, 'gun-ay-yil' olarak formatlanir ve string'e cevrilir.
Console.WriteLine(dateTime2); //output => 01/09/2022

string hour = DateTime.Now.ToString("HH:mm"); //Guncel saati formatlama(sisteme gore, saat ve dakika olarak).
Console.WriteLine(hour); //output => 00:55
