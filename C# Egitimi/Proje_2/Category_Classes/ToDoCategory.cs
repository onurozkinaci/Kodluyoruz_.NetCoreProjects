public class ToDoCategory : IBoardCategory
{
    private static List<Card> toDoCards = new List<Card>();
    public  void AddCard(Card card)
    {
      toDoCards.Add(card);
      Console.WriteLine("Kart basariyla 'yapilacak islemler kategorisine' eklendi!");
    }

    public void DeleteCard(string baslik) => toDoCards.Remove(KartiBul(baslik));
    public void MoveCard(string baslik, int category, Card card)
    {
       switch(category)
       {
          case 1: //TODO
               break;
          case 2: //IN PROGRESS
               toDoCards.Remove(KartiBul(baslik));
               InProgressCategory inProgress = new InProgressCategory();
               inProgress.AddCard(card);
               break;
          case 3: //DONE  
               toDoCards.Remove(KartiBul(baslik));
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
            for(int i=0; i<toDoCards.Count; i++)
            {
                if(toDoCards[i].Baslik == baslik)
                {
                   arananKart = toDoCards[i];
                   break;
                }
            }
       }
       else
        Console.WriteLine("Baslik bos olamaz, lutfen basligi giriniz!");
       return arananKart;
    }

    public static void ListToDoCards()
    {
       Console.WriteLine("ToDo Line");
       Console.WriteLine("************************");
       if(toDoCards.Count == 0)
         Console.WriteLine("~BOŞ~");
       else
       {
         for(int i=0;i<toDoCards.Count;i++)
         {
            Console.WriteLine("Baslik : {0}", toDoCards[i].Baslik);
            Console.WriteLine("Icerik : {0}",toDoCards[i].Icerik);
            Console.WriteLine("Atanan kisi : {0}",toDoCards[i].AtananKisi);
            Console.WriteLine("Buyukluk : {0}",toDoCards[i].buyukluk);
            Console.WriteLine("-");
         } 
       }
    }
}