//C#-Karakter Degistirme;
/*Verilen string ifade içerisindeki ilk ve son karakterin yerini değiştirip tekrar ekrana yazdıran console
 uygulamasını yazınız.
Örnek: Input: Merhaba Hello Algoritma x
Output: aerhabM oellH algoritmA x
*/

Console.WriteLine("Kelimelerinde degisiklik yapilmasini istediginiz cumleyi giriniz.");
string cumle = Console.ReadLine();
string[] kelimeler = cumle.Split(" ");
for (int i=0; i<kelimeler.Length; i++)
{
   char[] harfler = kelimeler[i].ToCharArray();
   char temp = harfler[0];
   harfler[0] = harfler[harfler.Length-1];
   harfler[harfler.Length-1] = temp;
   kelimeler[i] = new string(harfler);
   Console.Write(kelimeler[i] + " ");
}

