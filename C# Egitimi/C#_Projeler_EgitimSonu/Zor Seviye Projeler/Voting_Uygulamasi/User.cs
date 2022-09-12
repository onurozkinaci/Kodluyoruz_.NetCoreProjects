public class User
{
   private string name;
   private string surname;
   private string username;

   public User(string name, string surname, string username)
   {
      this.Name = name;
      this.Surname = surname;
      this.Username = username;
   }

    public string Name { get => name; set => name = value; }
    public string Surname { get => surname; set => surname = value; }
    public string Username { get => username; set => username = value; }
}