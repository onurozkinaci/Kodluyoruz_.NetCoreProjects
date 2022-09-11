///Tip Donusumleri;
//Implicit Conversion-Bilincsiz Donusum;
//=>Dusuk kapasiteli bir degiskenin kendinden daha yuksek kapasiteli bir degiskene atanma islemidir;
Console.WriteLine("---Implicit Conversion---");
byte a = 5;
sbyte b = 30;
short c = 10;

int d = a+b+c; //int'in kapasitesi bu degiskenlerden daha yuksek old. icin bu atama islemini yapabildim,implicit conversion oldu otomatik olarak.
Console.WriteLine(d);

long h = d; //long'un kapasitesi int'ten fazla old. hata vermez bu atamada,implicit conversion yapar.
Console.WriteLine(h);

float i = h;
Console.WriteLine(i);

string e = "Onur";
char f = 'k';
object g = e+f+d;
Console.WriteLine(g); //Onurk45

//Explicit Conversion-Bilincli Donusum => Belirtmeden derleyicinin otomatik yapamadigi donusumlerdir;
Console.WriteLine("---Explicit Conversion---");
int x = 4;
byte y = (byte)x;//byte, int'ten daha dusuk kapasitede bir veri tipi old. otomatik/implicit conversion ile atama saglanamaz,conversion'in explicit bir sekilde belirtilmesi gerekir.
//(byte) x ile int degisken byte veri tipine cast edilebilir.
Console.WriteLine(y);

int z = 100;
byte t = (byte)z;
Console.WriteLine(t);

float w = 10.3f;
byte v = (byte)w;
Console.WriteLine(v); //output = 10

//---ToString() metodu - Aldigi veriyi string'e cast eder--;
int xx = 6;
string yy = xx.ToString();
Console.WriteLine(yy);

string zz = 12.5f.ToString();
Console.WriteLine(zz);

//System.Convert sinifi;
Console.WriteLine("--System.Convert Sinifi--");
string s1 = "10", s2 = "20";
int sayi1,sayi2;
int toplam;

sayi1 = Convert.ToInt32(s1);
sayi2 = Convert.ToInt32(s2);
toplam = sayi1 + sayi2;
Console.WriteLine("Toplam:" + toplam);

//Parse;
Console.WriteLine("--Parse Metodu--");
ParseMethod();

static void ParseMethod()
{
  //Parse parametre olarak her zaman string veri tipinde degisken kabul eder;
  string metin1 = "10";
  string metin2 = "10,25"; 
  int rakam1;
  double double1;
  
  rakam1 = Int32.Parse(metin1);
  double1 = Double.Parse(metin2);
  Console.WriteLine("rakam 1: "+ rakam1);
  Console.WriteLine("double 1: "+ double1);
}


