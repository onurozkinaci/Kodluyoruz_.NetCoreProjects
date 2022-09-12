//C#-Voting Uygulamasi;
//Manuel olarak program oncesinde ekleme yapilan kisim;
User user = new User("Onur","Ozk","onrozk");
User user2 = new User("Arda","Demir","ademir");
User user3 = new User("Merve","Gulsen","mgulsen");
User user4 = new User("Deniz","Duran","deduran");
List<User>users = new List<User>{user,user2,user3,user4};

Film_Category filmKategorisi;
Film_Category f1 = new Film_Category(FilmCategories.Korku,5);
Film_Category f2 = new Film_Category(FilmCategories.Dram,10);
Film_Category f3 = new Film_Category(FilmCategories.Komedi,7);
Film_Category f4 = new Film_Category(FilmCategories.Romantik_Komedi,8);
List<Film_Category>kategoriler = new List<Film_Category>(){f1,f2,f3,f4};


//Kullanicidan-konsoldan veri alinan kisim;
try
{
  bool flag = false;
  Console.Write("Lutfen kullanici adinizi giriniz: "); 
  string username = Console.ReadLine();
  flag = CheckUserInfo(username);
  if(flag == false)
  {
    Console.WriteLine("----------------------------------");
    Console.WriteLine("Boyle bir kullanici bulunamadi, lutfen once kaydolun!");
    Register();
    KategoriSec();
  }  
  else //flag == true
    KategoriSec();
  OyOranlariniGoster();
}
catch (System.Exception e)
{
  Console.WriteLine(e.Message);
}

bool CheckUserInfo(string username)
{
  bool flag = false;
  for (int i=0; i<users.Count; i++)
  {
    if(users[i].Username == username)
    {
      flag = true;
      break;  
    }
  }
  return flag;
}

void Register()
{
  Console.Write("Lutfen adinizi giriniz: ");
  string name = Console.ReadLine();
  Console.Write("Lutfen soyadinizi giriniz: ");
  string surname = Console.ReadLine();
  Console.Write("Lutfen kullanici adinizi giriniz: ");
  string username = Console.ReadLine();
  User newUser = new User(name,surname,username);
  users.Add(newUser);
  Console.WriteLine("Kaydiniz basariyla olusturuldu.");
  Console.WriteLine("-------------------------------------------");
}

void OyOranlariniGoster()
{
   //=>Direkt KategoriGuncelle mantigiyla direkt mevcut 'kategoriler' listesi de guncellenebilir;
   Dictionary<string,int>oyOranlari = new Dictionary<string, int>();
   //ilk basta default verilen degerler;
   oyOranlari["Korku"] = 0;
   oyOranlari["Dram"] = 0;
   oyOranlari["Komedi"] = 0;
   oyOranlari["Romantik Komedi"] = 0;
   int toplamOy = 0;

   for (int i=0; i<kategoriler.Count;i++)
   {
      if(kategoriler[i].FilmKategorisi == FilmCategories.Korku)
        oyOranlari["Korku"] += kategoriler[i].GuncelOyOrani;
      else if(kategoriler[i].FilmKategorisi == FilmCategories.Dram)
        oyOranlari["Dram"] += kategoriler[i].GuncelOyOrani;
      else if(kategoriler[i].FilmKategorisi == FilmCategories.Komedi)
        oyOranlari["Komedi"] += kategoriler[i].GuncelOyOrani;
      else //Romantik_Komedi
        oyOranlari["Romantik Komedi"] += kategoriler[i].GuncelOyOrani;
      toplamOy += kategoriler[i].GuncelOyOrani;
   }
   Console.WriteLine("-----------------------------------------------------");
   double yuzdelik = 0;
   string sonuc = "";
   foreach (var item in oyOranlari)
   {
      Console.WriteLine("{0} filmleri kategorisi icin oy miktari: {1}",item.Key,item.Value);
      yuzdelik = (double)item.Value/(double)toplamOy * 100;
      sonuc = String.Format("{0:0.00}", yuzdelik); //virgulden (decimal point) sonra yalnizca iki basamak alacak.
      Console.WriteLine("{0} filmleri kategorisi icin yuzdelik oy miktari: {1}",item.Key,sonuc);
   }
}

void KategoriSec()
{
    Console.WriteLine("Hos geldiniz, oy vermek istediginiz film kategorisini seciniz.");
    Console.WriteLine("(1)Korku");
    Console.WriteLine("(2)Dram");
    Console.WriteLine("(3)Komedi");
    Console.WriteLine("(4)Romantik_Komedi");
    int secim = int.Parse(Console.ReadLine());
    Console.Write("Verdiginiz oy degerini giriniz: ");
    int deger = int.Parse(Console.ReadLine());
    switch (secim)
    {
      case 1:      
           filmKategorisi = new Film_Category(FilmCategories.Korku,deger);
           KategoriGuncelle(filmKategorisi);
           break;
      case 2:
           filmKategorisi = new Film_Category(FilmCategories.Dram,deger);
           KategoriGuncelle(filmKategorisi);
           break;
      case 3:
           filmKategorisi = new Film_Category(FilmCategories.Komedi,deger);
           KategoriGuncelle(filmKategorisi);
           break;
      case 4:
           filmKategorisi = new Film_Category(FilmCategories.Romantik_Komedi,deger);
           KategoriGuncelle(filmKategorisi);
           break;
      default:
           break;
    }  
}

void KategoriGuncelle(Film_Category film_Category)
{
   for(int i=0; i<kategoriler.Count; i++)
   {
      if(kategoriler[i].FilmKategorisi == film_Category.FilmKategorisi)
        kategoriler[i].GuncelOyOrani += film_Category.GuncelOyOrani; //mevcut olan degere eklenerek guncellenecek
   }
}
