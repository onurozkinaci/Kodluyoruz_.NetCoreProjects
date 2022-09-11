public interface IBoardCategory
{
  void AddCard(Card card);
  void DeleteCard(string baslik);
  //void UpdateCard(Card card);
  void MoveCard(string baslik, int category,Card card);
  Card KartiBul(string baslik);
}