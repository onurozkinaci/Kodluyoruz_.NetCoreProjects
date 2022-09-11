//C#-Sessiz Harf Bulma;
Console.Write("Bir cumle giriniz: ");
string girilenDeger = Console.ReadLine();
string kelime = "";
char[] sessizHarfler = new char[]{'z','y','v','t','ş','s','r','p','n','r','m','l','k','h','j','ğ','g','d','ç','c','b'};
bool flag = false;
string[] sptArray = girilenDeger.Split(" ");
for (int i=0; i<sptArray.Length; i++)
{
    char[] harfler = sptArray[i].ToLower().ToCharArray();
    flag = false;
    for (int j = 0; j < harfler.Length; j++)
    {
       if(j+1 != harfler.Length)
       {
         if(sessizHarfler.Contains(harfler[j]) && sessizHarfler.Contains(harfler[j+1]))
         {
            flag = true;
            break;
         }
       }
    }
    Console.Write(flag + " ");
}


