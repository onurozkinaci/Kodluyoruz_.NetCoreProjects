public class NewCivic : Otomobil
{
    public override Marka HangiMarkaninAraci()
    {
      return Marka.Honda;
    }

    //Rengi farkli old. icin ust sinifta virtual tanimlanan bu metot override edilir;
    public override Renk StandartRengiNe()
    {
        return Renk.Gri;
    }
}