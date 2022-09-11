//**Onceki Focus classindan farkli olarak interfaceten degil, abstract class'tan miras
//alir ve eski yapinin refactor edilmis hali kazandirilir gibi dusunebilirsin;
public class NewFocus : Otomobil
{
    public override Marka HangiMarkaninAraci()
    {
      return Marka.Ford;
    }
}