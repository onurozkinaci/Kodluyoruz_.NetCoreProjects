public class Corolla : IOtomobil
{
    public Marka HangiMarkaninAraci()
    {
       return Marka.Toyota;
    }

   //Bu metot su anda tum classlar icin 4 degerini dondurdugunden
   //aslinda bir ozellestirme saglanmamis oluyor ve interfacete metot imzasi tanimlayip
   //diger classlarda govdesi kullanilacak bir class olarak verilmesi pek mantikli olmuyor.
   //Bu ve bunun gibi durumlari refactor etmek icin de "Abstract Classlara" basvurulabilir;
    public int KacTekerlektenOlusur()
    {
       return 4;
    }

    public Renk StandartRengiNe()
    {
       return Renk.Beyaz;
    }
}