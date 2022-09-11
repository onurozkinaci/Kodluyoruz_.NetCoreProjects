public class DoneCategory : IBoardCategory
{
    private static List<Card>doneCards = new List<Card>();

    public void AddCard(Card card)
    {
      doneCards.Add(card);
      Console.WriteLine("Kart basariyla 'yapilan islemler kategorisine' eklendi!");
    }

    public void DeleteCard(string baslik) => doneCards.Remove(KartiBul(baslik));

    public void MoveCard(string baslik, int category, Card card)
    {
       switch(category)
       {
          case 1: //TODO
               doneCards.Remove(KartiBul(baslik));
               ToDoCategory toDoCategory = new ToDoCategory();
               toDoCategory.AddCard(card);
               break;
          case 2: //IN PROGRESS
               doneCards.Remove(KartiBul(baslik));
               InProgressCategory inProgress = new InProgressCategory();
               inProgress.AddCard(card);
               break;
          case 3: //DONE              
               break;
          default:
                break;
       }
    }

    /*public void UpdateCard(Card card)
    {
        throw new NotImplementedException();
    }*/

    public Card KartiBul(string baslik)
    { 
       bool flag= false;
       Card arananKart = new Card();
       if(baslik != "")
       {
            for(int i=0; i<doneCards.Count; i++)
            {
                if(doneCards[i].Baslik == baslik)
                {
                   arananKart = doneCards[i];
                   flag = true;
                   break;
                }
            }
       }
       else
         Console.WriteLine("Baslik bos olamaz, lutfen basligi giriniz!");
       if(flag == false)
            arananKart = null;
       return arananKart;
    }

    public static void ListDoneCards()
    {
       Console.WriteLine("Done Line");
       Console.WriteLine("************************");
       if(doneCards.Count == 0)
         Console.WriteLine("~BOŞ~");
       else
       {
         for(int i=0;i<doneCards.Count;i++)
         {
            Console.WriteLine("Baslik : {0}", doneCards[i].Baslik);
            Console.WriteLine("Icerik : {0}",doneCards[i].Icerik);
            Console.WriteLine("Atanan kisi : {0}",doneCards[i].AtananKisi);
            Console.WriteLine("Buyukluk : {0}",doneCards[i].buyukluk);
            Console.WriteLine("-");
         } 
       }
    }
}