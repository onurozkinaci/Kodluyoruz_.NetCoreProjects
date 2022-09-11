//Class'in instance'ini alma;
Dikdortgen dikdortgen = new Dikdortgen();
dikdortgen.KisaKenar = 3;
dikdortgen.UzunKenar = 4;
Console.WriteLine("Class alan hesabi: {0}",dikdortgen.AlanHesapla());

//Struct Yapilari;
/*=>Structlarin classlardan bir diger farki instance alirken new keyword'unun kullanilma zorunlulugu olmamasidir.
Bu kullanimin getirdigi classlarla fark yaratan bir durum ise, classlarda default constructor ile otomatik olarak 
initialize edilmeyen field degerlrei null veya 0 olarak atanirken, structlarda bu durum gerceklesmemis oluyor, default
constructor ile bu atamanin yapilabilmesi icin "new" keyword'u ile instance alinmali veya new keywrodu olmadan instance aliniyorsa
sonrasinda fieldlara manuel baslangic degeri atanmali.
*/
//Dikdortgen_Struct dikdortgen_Struct;
//Dikdortgen_Struct dikdortgen_Struct = new Dikdortgen_Struct();
Dikdortgen_Struct dikdortgen_Struct = new Dikdortgen_Struct(3,4);
/*dikdortgen_Struct.KisaKenar = 3;
dikdortgen_Struct.UzunKenar = 4;*/
Console.WriteLine("Struct alan hesabi: {0}",dikdortgen_Struct.AlanHesapla());

/*Struct Yapilari;
=>Deger(value) tipindedir. Sinifilara cok benzese de en temel farklarindan birisi budur.
Classlarin isimleri stack'te degerleri heap'te tutulurken, structlarin degeri direkt bellegin stack
bolgesinde tutulur(Deger tipli old.icin, classlar referans tipindedir).
=>Structlarin instance'i alinirken "new" keywordunun kullanimi zorunlu degildir,
ornegi yukaridaki gibidir.
*/
class Dikdortgen 
{
  public int KisaKenar;
  public int UzunKenar;

  public Dikdortgen(){}
  public long AlanHesapla()
  {
     return this.KisaKenar * this.UzunKenar;
  }  
}

struct Dikdortgen_Struct
{
  public int KisaKenar;
  public int UzunKenar;
  
  //=>Onceden parametre kullanmadan bu sekilde default constructor'i tanimlamayi kabul etmiyordu
  //fakat su anda(.NET 6.0 ile birlikte) ediyor. Tek farki, parametresiz oldugundan classtakinin aksine
  //public erisim belirtecini burada vermezsen hata alirsin;
  public Dikdortgen_Struct()
  { KisaKenar=3;
    UzunKenar = 4;
  } 
  
  public Dikdortgen_Struct(int kisaKenar, int uzunKenar) //parametre ile constuctor olusturmaya izin verir.
  {
     KisaKenar = kisaKenar;
     UzunKenar = uzunKenar;
  }
  public long AlanHesapla()
  {
     return this.KisaKenar * this.UzunKenar;
  }   
}