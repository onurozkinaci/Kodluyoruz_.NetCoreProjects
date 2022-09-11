/*Inheritance-Kalitim;
=>Bir ust sinifin alt sinifa miras vermesiyle alt sinifin ust sinifa ait ozellikleri
kendisine aitmis gibi kullanabilmesi saglanir.
                Canlilar
                    |
    Bitkiler                  Hayvanlar
   |        |                |          |
Tohumlu  Tohumsuz       Surungenler   Kuslar
*/

TohumluBitkiler tohumluBitki = new TohumluBitkiler();
/*=>TohumluBitkiler sinifinin constructor'i icerisinde asagidaki bu metotlar cagrildigindan, instance alininca
metotlar direkt calisir, ayrica cagrildiginda bu metotlar ust sinifa ait protected metotlar oldugundan erisilemezler;
tohumluBitki.Beslenme();//Canlilar sinifindan gelir(miras alma/kalitim ile)
tohumluBitki.Solunum(); //Canlilar sinifindan gelir(miras alma/kalitim ile)
tohumluBitki.Bosaltim();//Canlilar sinifindan gelir(miras alma/kalitim ile)
*/
tohumluBitki.TohumlaCogalma(); //kendi sinifinda tanimlidir
Console.WriteLine("----------------------");

Kuslar marti = new Kuslar();
/*=>Kuslar sinifinin constructor'i icerisinde asagidaki bu metotlar cagrildigindan, instance alininca
metotlar direkt calisir, ayrica cagrildiginda bu metotlar ust sinifa ait protected metotlar oldugundan erisilemezler;
marti.Solunum();
marti.Beslenme();
marti.Bosaltim();
*/
marti.Ucmak();


