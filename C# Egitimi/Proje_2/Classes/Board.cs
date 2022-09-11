//=>Bu class uzerinden diger classlarin management'i(yonetimi) saglanacak;
public class Board : IBoardCategory
{
    private IBoardCategory _boardCategory;

    public Board(IBoardCategory boardCategory)
    {
       _boardCategory = boardCategory; //IBoardCategory'den miras alan kategori constructora parametre olarak gonderildiginde
       //bu referans uzerinden ekleme,cikarma gibi islemler yaptirilacak.
    }

    public Board(){}

    public void AddCard(Card card) => _boardCategory.AddCard(card); //dinamik olarak referans uzerinden ilgili borad kategorisine ekleme yapilacak, kendi classlari icerisindeki add metodu uzerinden

    public void DeleteCard(string baslik) => _boardCategory.DeleteCard(baslik);
    public void MoveCard(string baslik, int category,Card card) => _boardCategory.MoveCard(baslik,category,card);

    /*public void UpdateCard(Card card)
    {
        throw new NotImplementedException();
    }
    */


    public void ListTheBoard()
    {
      ToDoCategory.ListToDoCards();
      InProgressCategory.ListInProgressCards(); //static bir metot oldugundan instance almadan tanimlanabilir
      DoneCategory.ListDoneCards();
    }

    public Card KartiBul(string baslik) => _boardCategory.KartiBul(baslik);
}