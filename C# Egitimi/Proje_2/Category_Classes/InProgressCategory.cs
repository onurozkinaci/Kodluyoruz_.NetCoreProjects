public class InProgressCategory : IBoardCategory
{
    private static List<Card> inProgressCards = new List<Card>();

    public  void AddCard(Card card)
    {
      inProgressCards.Add(card);
      Console.WriteLine("Kart basariyla 'yapilmakta olan islemler' kategorisine eklendi!");
    }

    public void DeleteCard(string baslik) => inProgressCards.Remove(KartiBul(baslik));

    public void MoveCard(string baslik, int category, Card card)
    {
       switch(category)
       {
          case 1: //TODO
               inProgressCards.Remove(KartiBul(baslik));
               ToDoCategory toDoCategory = new ToDoCategory();
               toDoCategory.AddCard(card);  
               break;
          case 2: //IN PROGRESS
               break;
          case 3: //DONE  
               inProgressCards.Remove(KartiBul(baslik));
               DoneCategory doneCategory = new DoneCategory();
               doneCategory.AddCard(card);            
               break;
          default:
                break;
       }
     }


    /*public void UpdateCard(Card card)
    {
        throw new NotImplementedException();
    }
    */
    public Card KartiBul(string baslik)
    {
       Card arananKart = new Card();
       if(baslik != "")
       {
            for(int i=0; i<inProgressCards.Count; i++)
            {
                if(inProgressCards[i].Baslik == baslik)
                {
                   arananKart = inProgressCards[i];
                   break;
                }
            }
       }
       else
        Console.WriteLine("Baslik bos olamaz, lutfen basligi giriniz!");
       return arananKart;
    }

    public static void ListInProgressCards()
    {
       Console.WriteLine("InProgress Line");
       Console.WriteLine("************************");
       if(inProgressCards.Count == 0)
         Console.WriteLine("~BOŞ~");
       else
       {
         for(int i=0;i<inProgressCards.Count;i++)
         {
            Console.WriteLine("Baslik : {0}", inProgressCards[i].Baslik);
            Console.WriteLine("Icerik : {0}",inProgressCards[i].Icerik);
            Console.WriteLine("Atanan kisi : {0}",inProgressCards[i].AtananKisi);
            Console.WriteLine("Buyukluk : {0}",inProgressCards[i].buyukluk);
            Console.WriteLine("-");
         } 
       }
    }
}