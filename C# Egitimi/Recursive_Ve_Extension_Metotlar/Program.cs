//Recursive ve Extension Metotlar;
namespace Recursive_Ve_Extension_Metotlar
{
   class Program
   {
     static void Main(String[] args)
     {
        //Recursive-Oz yinelemeli(kendi kendini cagiran) fonksiyonlar;
        //=>Ornegin: 3^4 =3*3*3*3;
        //Recursive olmayan yol ile;
        int result = 1;
        for (int i=1; i<5; i++)
        {
          result = result*3;  
        }
        Console.WriteLine(result);

        //Recursive fonksiyon ile;
        Islemler instance = new();
        Console.WriteLine(instance.Expo(3,4));

        //Extension Metotlar;
        string ifade = "Onur Ozk";
        bool sonuc = ifade.CheckSpaces();
        Console.WriteLine(sonuc);
        if(sonuc) //string icerisinde bosluk varsa bosluklari sil demis oluyoruz yani olusturdugumuz Extension metodu cagirarak;
           Console.WriteLine(ifade.RemoveWhiteSpaces());
        Console.WriteLine(ifade.MakeUpperCase());
        Console.WriteLine(ifade.MakeLowerCase());

        int[] dizi = {9,3,6,2,1,5,0};
        dizi.SortArray();
        dizi.EkranaYazdir();      

        Console.WriteLine(ifade.GetFirstChar());
     }
   } 

   public class Islemler 
   {
    //Recursive function;
     public int Expo(int sayi,int us)
     {
        if(us<2) //stop condition
          return sayi;
        return Expo(sayi,us-1)*sayi; //recursive part-fonksiyonun kendi kendini cagirdigi kisim
     }
   }

   //Extension classlara ve metotlara instance alinmadan ulasilabilmesi gerektigi icin 'static' olmalidir;
   public static class Extension
   {
    //=>Parametrenin basina 'this' eklediginde artik bu bir 'Extension Metot' olur.
    //Basina geldigi parametrenin veri tipi icin (burada string) artik bu bir Extension Metot olur;
     public static bool CheckSpaces(this string param)
     {
        return param.Contains(" ");
     }
     public static string RemoveWhiteSpaces(this string param)
     {
        string[] dizi = param.Split(" "); //string bosluklara gore ayrilip diziye cevrilir.
        return string.Join("*",dizi); //whitespace olmadan bu dizi elemanlarini aralarina '*' koyarak birlestirir ve string'e cevirir.
     }
     public static string MakeUpperCase(this string param)
     {
        return param.ToUpper();
     }
     public static string MakeLowerCase(this string param)
     {
        return param.ToLower();
     }
     public static int[] SortArray(this int[] param)
     {
        Array.Sort(param);
        return param;
     }
     public static void EkranaYazdir(this int[] param)
     {
        foreach (int item in param)
        {
          Console.WriteLine(item); 
        }
     }
     public static string GetFirstChar(this string param)
     {
        return param.Substring(0,1);
     }
   }
}
