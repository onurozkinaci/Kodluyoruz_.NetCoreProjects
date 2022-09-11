//=> Refactor edilmeyen yol ile(Interface'ten kalitim/miras alan classlari) cagirma;
Console.WriteLine("--------Non-refactored way/Interface--------");
Focus focus = new Focus();
Console.WriteLine(focus.HangiMarkaninAraci().ToString());
Console.WriteLine(focus.KacTekerlektenOlusur().ToString());
Console.WriteLine(focus.StandartRengiNe().ToString());
Console.WriteLine("-----------------------------");

Civic civic = new Civic();
Console.WriteLine(civic.HangiMarkaninAraci().ToString());
Console.WriteLine(civic.KacTekerlektenOlusur().ToString());
Console.WriteLine(civic.StandartRengiNe().ToString());
Console.WriteLine("-----------------------------");

//=>Abstract Classlar;
/*
-Sadece kalitim icin kullanilan siniflar gibi dusunulebilir.
-Interfaceler ve virtual metotlarin birlesimi gibi dusunulebilir.
-Normal siniflar gibi "new" keyword'u ile turetilemezler ve nesneleri yaratilamaz(instancelari alinamaz),
mutlaka bir sinif uzerinden turetilmeleri gerekir(referans mantigi ile, interfaceler gibi).
-Govdesi yazilarak veya yazilmayarak metotlar tanimlanabilir.
-Sanal(virtual) metotlari override ettigimiz gibi abstract class icerisinde tanimlanan abstract metotlar da
override edilebilir. Alt siniflarda bu abstract metotlar override edilmek zorundadir, govdesini yazmak da zorundalar!
-Bir sinif sadece tek bir abstract class'tan kalitim alabilir, normal classlar gibi. Abstract class baska bir abstract class'tan
kalitim alabilir ve bir alt sinifta miras olarak alindiginda aslinda bu en alttaki class birden cok abstract classtan miras almis olur.
*/
Console.WriteLine("--------Refactored way/Abstract--------");
//=> Refactor edilen yol ile(Abstract class'tan kalitim/miras alan classlari) cagirma;
NewFocus focus1 = new NewFocus();
Console.WriteLine(focus1.HangiMarkaninAraci().ToString());
Console.WriteLine(focus1.KacTekerlektenOlusur().ToString());
Console.WriteLine(focus1.StandartRengiNe().ToString());
Console.WriteLine("-----------------------------");

NewCivic civic1 = new NewCivic();
Console.WriteLine(civic1.HangiMarkaninAraci().ToString());
Console.WriteLine(civic1.KacTekerlektenOlusur().ToString());
Console.WriteLine(civic1.StandartRengiNe().ToString());
Console.WriteLine("-----------------------------");



