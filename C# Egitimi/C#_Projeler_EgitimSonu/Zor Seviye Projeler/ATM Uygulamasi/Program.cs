//C#-ATM Uygulamasi;
using System.IO;
string date = DateTime.Now.ToString("ddMMyyyy");
string fileName = date + ".txt";

//Default olarak eklenen veriler;
User user1 = new User("1","onrozk","123");
User user2 = new User("2","uaktas","1234");
User user3 = new User("3","dbilekci","12345");
User user4 = new User("4","tkangor","123456");
List<User>users = new List<User>(){user1,user2,user3,user4};
//--------
ATM_Transaction transaction = new ATM_Transaction();
transaction.HesapEkle(user1,100);
transaction.HesapEkle(user2,1000.25);
transaction.HesapEkle(user3,500.35);
transaction.HesapEkle(user4,250);
//--------

//Kullanicidan alinan veriler;
try
{
    bool flag = false;
    Console.Write("Lutfen kullanici adinizi giriniz: "); 
    string username = Console.ReadLine();
    Console.Write("Lutfen sifrenizi giriniz: "); 
    string password = Console.ReadLine();
    flag = CheckUserInfo(username,password);
    if(flag == false)
    {
      Console.WriteLine("----------------------------------");
      Console.WriteLine("Boyle bir kullanici bulunamadi, lutfen once kaydolun!");
      StreamWriter sw = new StreamWriter(fileName,true); //append = true ile mevcut dosyanin sonuna ekleme yapar, yeniden dosyayi olusturmaz. Dosya mevcut degilse de sifirdan olusturur.
      sw.WriteLine("{0} kullanici adli hesaba hatali giris yapildi!",username);
      sw.Close();
      Register();
      IslemSec();
    }  
    else //flag == true
       IslemSec();
}
catch (System.Exception e)
{
  Console.WriteLine(e.Message);
}

bool CheckUserInfo(string username,string password)
{
   bool contains = false;
   for (int i = 0; i < users.Count; i++)
   {
      if(users[i].Username == username && users[i].Password == password)
      {
         contains = true;
         break;
      }
   }
   return contains;
}

void Register()
{
  bool uNameExists = false, pwdExists = false;
  Console.Write("Lutfen id (hesap no) giriniz: ");
  string id = Console.ReadLine();
  Console.Write("Lutfen kullanici adinizi giriniz: ");
  string username = Console.ReadLine();
  Console.Write("Lutfen sifrenizi giriniz: ");
  string password = Console.ReadLine();
  for (int i = 0; i < users.Count; i++)
  {
    if(users[i].Id == id)
    {
      pwdExists = true;
      break;
    }
    else if(users[i].Username == username)
    {
      uNameExists = true;
      break;
    }
  }
  if(uNameExists == true)
  {
    Console.WriteLine("Bu kullanici adi kullaniliyor, lutfen baska bir kullanici adi ile kaydolunuz.");
    Register();
  }
  if(pwdExists == true)
  {
    Console.WriteLine("Bu id (hesap no) baska bir kullanici tarafindan kullaniliyor, lutfen baska bir id ile kaydolunuz.");   
    Register();
  }
  User newUser = new User(id,username,password);
  users.Add(newUser);
  Console.WriteLine("Kaydiniz basariyla olusturuldu.");
  Console.WriteLine("-------------------------------------------");
}

void IslemSec()
{
  bool sonuc = false;
  Console.WriteLine("Lutfen yapmak istediginiz islemi seciniz.");
  Console.WriteLine("(1)Para Cek");
  Console.WriteLine("(2)Para Yatir");
  Console.WriteLine("(3)Odeme Yap");
  Console.WriteLine("(4)Gun Sonu Raporu Al");
  //-----------
  int secim = int.Parse(Console.ReadLine());
  if(secim == 4)
  {
    transaction.GunSonuAl(); //log dosyasindaki verileri ekrana yazdirir.
    return;
  }
  Console.Write("Lutfen id'nizi (hesap no) giriniz: ");
  string id = Console.ReadLine();
  Console.Write("Islem yapilacak tutari giriniz: ");
  double tutar = double.Parse(Console.ReadLine());
  StreamWriter sw = new StreamWriter(fileName,true); //Islemi log'a yazmak icin.
  switch (secim)
  {
    case 1:
          sonuc = transaction.ParaCekme(id,tutar);
          //islem basailiysa dosyaya yazdir, degilse yazdirma;
          if(sonuc == true)
            sw.WriteLine("{0} id'li hesaptan {1} TL cekildi.",id,tutar);
          sw.Close();
          DevamKarari(); //tekrar islem yapmak icin
          break;
    case 2:
          sonuc = transaction.ParaYatirma(id,tutar);
          if(sonuc == true)
             sw.WriteLine("{0} id'li hesaba {1} TL eklendi.",id,tutar);
          sw.Close();
          DevamKarari();
          break;
    case 3:
          Console.Write("Para gonderilecek hesabin id'sini giriniz: ");
          string aliciId = Console.ReadLine();
          sonuc = transaction.OdemeYapma(tutar,id,aliciId);
          if(sonuc == true)
             sw.WriteLine("{0} id'li hesaptan {1} id'li hesaba {2} TL aktarildi.",id,aliciId,tutar);
          sw.Close();
          DevamKarari();
          break;
    default:
         sw.Close();
         break;
  }
}

void DevamKarari()
{
  Console.Write("Islemlere devam etmek istiyor musunuz (y/n)? ");
  string cevap = Console.ReadLine();
  if(cevap == "y")
     IslemSec();
  else
     return;
}
