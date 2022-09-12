public class Film_Category
{
   private FilmCategories filmKategorisi;
   private int guncelOyOrani =0;

    public FilmCategories FilmKategorisi { get => filmKategorisi; set => filmKategorisi = value; }
    public int GuncelOyOrani { get => guncelOyOrani; set => guncelOyOrani = value; }

    public Film_Category(FilmCategories filmKategorisi, int oyOrani)
   {
      this.FilmKategorisi = filmKategorisi;
      this.GuncelOyOrani += oyOrani;
   }

   public Film_Category(){}

   //public void OyArttir() => this.GuncelOyOrani++;
   
}

public enum FilmCategories
{
   Korku = 1, Dram, Komedi, Romantik_Komedi
}