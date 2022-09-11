//If-ElseIf-Ternary If;
int time = DateTime.Now.Hour;
if(time>=6 && time<11)
  Console.WriteLine("Gunaydin!");
else if(time<=18)
   Console.WriteLine("Iyi gunler!");
else
  Console.WriteLine("Iyi geceler!");

//Ternary if =>tek satirda if kosulunu verme;
string sonuc = time<=18 ? "Iyi gunler" : "Iyi geceler";
//Asagida iki farkli ternary isliyor gibi dusun;
sonuc = time>=6 && time<11 ? "Gunaydin": time<=18 ? "Iyi gunler": "Iyi geceler";
Console.WriteLine(sonuc);

//*=>Switch-Case Kullanimi;
Console.WriteLine("---------Switch-Case Kullanimi------");
int month = DateTime.Now.Month;
switch (month) //expression => case'de kullanilan veri tipi expression'in veri tipi ile ayni olmali(burada integer/int);
{
  case 1:
     Console.WriteLine("January");
     break;
  case 2:
     Console.WriteLine("February");
     break;
  case 9: //sirayla ilerlemek zorunda degil, 9'u 3'ten once verdik;
     Console.WriteLine("September");
     break;
  case 3:
     Console.WriteLine("March");
     break;   
  default: //Hicbir case'e uymazsa buraya girer
     Console.WriteLine("Yanlis veri girisi!");
     break;
}

switch (month) //expression => case'de kullanilan veri tipi expression'in veri tipi ile ayni olmali(burada integer/int);
{
  //**Asagidaki gibi(12,1,2) ayni sonucu verecek caseler alt alta siralanip bunlarin altinda tek bir islem de yaptirilabilir!
  case 12:
  case 1:
  case 2:
      Console.WriteLine("Kis ayindasiniz!");
      break;  
  case 3:
  case 4:
  case 5:
      Console.WriteLine("Ilkbahar ayindasiniz!");
      break;
  case 6:
  case 7:
  case 8:
      Console.WriteLine("Yaz ayindasiniz!");
      break;  
  case 9:
  case 10:
  case 11:
      Console.WriteLine("Sonbahar ayindasiniz!");
      break;    
  default: //Hicbir case'e uymazsa buraya girer
     Console.WriteLine("Yanlis veri girisi!");
     break;
}





