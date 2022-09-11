public abstract class Otomobil
{
   //Her class icin ayni donecek bir deger old. her classta artik
   //bu metodu tek tek kullanmama gerek kalmaz, bu class'i miras vermem yeterli artik;
   public int KacTekerlektenOlusur()
   {
     return 4;
   }

   //2 class icin ayni 1 class icin farkli deger donen metot gibi bir durum old.
   //asagidaki metot icin default tanim yapip baska yerlerden ezilmesine veya baska bir cevap
   //donmesine izin vermemiz gerekiyor ve bunun icin sanal bir metot donebiliriz(virtual-override iliskisi => Polymorphism);
   public virtual Renk StandartRengiNe()
   {
      return Renk.Beyaz;
   }

   //**Ortak ozellik olmayan ve interfacete yalnizca govde olarak tanimladigimiz ve classlar icerisinde govdesi o classa 
   //ozgu olarak degistirilen/ozellestirilen metot "abstract" keywordu ile tanimlanabilir ve boylece alt siniflar bunu implemente edip govdesini
   //yazmaya zorunlu tutulmus olur ve bu da virtual gibi "override" keyword'u ile alt sinifta ezilir/override edilir;
   public abstract Marka HangiMarkaninAraci();
}